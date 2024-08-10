using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SpawnDev.BlazorJS.BrowserExtension.Build.Tasks
{
    public static class JsonObjectExtensions
    {
        public static List<string> GetPropertyNames(this JsonObject _this) => _this.Select(o => o.Key).ToList();
        public static JsonObject Merge(this JsonObject _this, JsonObject newerProperties)
        {
            var ret = new JsonObject();
            var origKeys = _this.GetPropertyNames();
            var newerKeys = newerProperties.GetPropertyNames();
            var allKeys = origKeys.Union(newerKeys).ToList();
            foreach(var key in allKeys)
            {
                if (newerKeys.Contains(key))
                {
                    ret.Add(key, newerProperties[key].DeepClone());
                }
                else
                {
                    ret.Add(key, _this[key].DeepClone());
                }
            }
            return ret;
        }
    }
    public class PostPublishTask : Microsoft.Build.Utilities.Task
    {

        [Required]
        public ITaskItem[] StaticWebAsset { get; set; }

        [Required]
        public string ProjectDir { get; set; }

        [Required]
        public string OutputPath { get; set; }

        [Required]
        public string BasePath { get; set; }

        [Required]
        public string IntermediateOutputPath { get; set; }

        [Required]
        public bool PatchFramework { get; set; }

        [Required]
        public string PackageContentDir { get; set; }

        [Required]
        public bool DebugSpawnDevBrowserExtensionBuildTasks { get; set; }

        [Required]
        public bool PublishMode { get; set; }
        /// <summary>
        /// If true, messages are upgraded to warnings
        /// </summary>
        public bool Verbose { get; set; }

        public string ExtensionPlatforms { get; set; }

        public string OutputWwwroot { get; set; }

        public bool DryRun { get; set; } = false;

        public override bool Execute()
        {
            LogMessage($"**********************************  PostPublishTask.Execute  **********************************");
            if (DebugSpawnDevBrowserExtensionBuildTasks)
            {
                System.Diagnostics.Debugger.Launch();
            }
            if (string.IsNullOrWhiteSpace(ExtensionPlatforms) || ExtensionPlatforms == "0" || ExtensionPlatforms.Equals("false", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (!PublishMode)
            {
                return true;
            }
            OutputWwwroot = Path.GetFullPath(Path.Combine(OutputPath, "wwwroot"));
            PackageContentDir = string.IsNullOrEmpty(PackageContentDir) ? "" : Path.GetFullPath(PackageContentDir);
            //
            var files = Directory.GetFiles(OutputWwwroot, "manifest.*.json");
            var manifestPlatforms = files.Select(o => string.Join(".", Path.GetFileNameWithoutExtension(o).Split('.').Skip(1))).ToArray();
            //
            var extensionPlatforms = string.IsNullOrEmpty(ExtensionPlatforms) ? manifestPlatforms : ExtensionPlatforms.Split(';').Select(o => o.Trim()).ToArray();
            LogMessage($"Platforms: {string.Join(", ", extensionPlatforms)}");
            foreach (var extensionPlatform in extensionPlatforms)
            {
                PublishPlatform(extensionPlatform);
            }
            LogMessage($"Publish platforms complete");
            //
            return true;
        }
        void LogMessage(string msg)
        {
            if (Verbose) LogWarning($"VERBOSE: {msg}");
            else Log?.LogMessage($"BrowserExtension: {msg}");
        }
        void LogWarning(string msg)
        {
            Log?.LogWarning($"BrowserExtension: {msg}");
        }
        static JsonSerializerOptions DefaultJsonSerializerOptions { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = false,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
        };
        void PublishPlatform(string platform)
        {
            var publishWwwrootPath = Path.GetFullPath(Path.Combine(OutputPath, "wwwroot"));
            var platformOutputPath = Path.GetFullPath(Path.Combine(OutputPath, platform));
            var platformAppOutputPath = Path.Combine(platformOutputPath, "app");
            // copy the wwwroot folder to the platform's app folder
            CopyDirectory(publishWwwrootPath, platformAppOutputPath);
            // get the shared manifest.json path
            var platformAppSharedManifestPath = Path.Combine(platformAppOutputPath, "manifest.json");
            // read the common manifest
            var manifestJson = File.ReadAllText(platformAppSharedManifestPath, Encoding.UTF8);
            // read platform specific manifest (if it exists) to merge with the main one
            var platformAppManifestPaths = Directory.GetFiles(platformAppOutputPath, "manifest.*.json").ToList();
            var platformAppManifestPath = platformAppManifestPaths.FirstOrDefault(o => Path.GetFileName(o).Equals($"manifest.{platform}.json", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(platformAppManifestPath) && File.Exists(platformAppManifestPath))
            {
                // merge with the shared
                var manifestPlatformStr = File.ReadAllText(platformAppManifestPath);
                var manifestCommon = JsonSerializer.Deserialize<JsonNode>(manifestJson, DefaultJsonSerializerOptions).AsObject();
                var manifestPlatform = JsonSerializer.Deserialize<JsonNode>(manifestPlatformStr, DefaultJsonSerializerOptions).AsObject();
                var manifestFinal = manifestCommon.Merge(manifestPlatform);
                manifestJson = manifestFinal.ToJsonString(DefaultJsonSerializerOptions);
            }
            // remove all manifests from platform /app/ folder
            platformAppManifestPaths.ForEach(o => File.Delete(o));
            File.Delete(platformAppSharedManifestPath);
            // save the final manifest to the platform / folder
            var platformOutputManifestPath = Path.Combine(platformOutputPath, "manifest.json");
            File.WriteAllText(platformOutputManifestPath, manifestJson, Encoding.UTF8);
        }
        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive = true)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);
            // Check if the source directory exists
            if (!dir.Exists) throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();
            // Create the destination directory
            Directory.CreateDirectory(destinationDir);
            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }
            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir);
                }
            }
        }
    }
}
