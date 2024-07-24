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

        public string ExtensionPlatforms { get; set; }

        public string OutputWwwroot { get; set; }

        public bool DryRun { get; set; } = false;

        public override bool Execute()
        {
#if DEBUG && false
            Log?.LogWarning($"**********************************  PostPublishTask.Execute  **********************************");
#endif
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
            var extensionPlatforms = ExtensionPlatforms.Split(';').Select(o => o.Trim());
            foreach(var extensionPlatform in extensionPlatforms)
            {
                PublishPlatform(extensionPlatform);
            }
            //
            return true;
        }
        void PublishPlatform(string platform)
        {
            var outputWwwrootPath = Path.GetFullPath(Path.Combine(OutputPath, "wwwroot"));
            var extensionOutputPath = Path.GetFullPath(Path.Combine(OutputPath, platform));
            var extensionOutputAppPath = Path.Combine(extensionOutputPath, "app");
            // copy the wwwroot folder to the platform's app folder
            CopyDirectory(outputWwwrootPath, extensionOutputAppPath, true);
            // get the common manifest.json path
            var manifestOrigPath = Path.Combine(extensionOutputAppPath, "manifest.json");
            // read the common manifest
            var manifestStr = File.ReadAllText(manifestOrigPath, Encoding.UTF8);
            // read platform specific manifest (if it exists) to merge with the main one
            var manifestPaths = Directory.GetFiles(extensionOutputAppPath, "manifest.*.json").ToList();
            var manifestPlatformSrcPath = manifestPaths.FirstOrDefault(o => {
                var filename = Path.GetFileNameWithoutExtension(o);
                var platformName = filename.Substring(filename.IndexOf(".") + 1);
                return platform.Equals(platformName, StringComparison.OrdinalIgnoreCase);
            });
            if (!string.IsNullOrEmpty(manifestPlatformSrcPath) && File.Exists(manifestPlatformSrcPath))
            {
                var manifestPlatformStr = File.ReadAllText(manifestPlatformSrcPath);
                var manifestCommon = JsonSerializer.Deserialize<JsonNode>(manifestStr, new JsonSerializerOptions { AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip }).AsObject();
                var manifestPlatform = JsonSerializer.Deserialize<JsonNode>(manifestPlatformStr, new JsonSerializerOptions { AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip }).AsObject();
                var manifestFinal = manifestCommon.Merge(manifestPlatform);
                manifestStr = manifestFinal.ToJsonString(new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            }
            // remove all manifests from app folder
            manifestPaths.ForEach(o => File.Delete(o));
            File.Delete(manifestOrigPath);
            // save the final manifest to the platform folder
            var manifestDestPath = Path.Combine(extensionOutputPath, "manifest.json");
            File.WriteAllText(manifestDestPath, manifestStr, Encoding.UTF8);
        }
        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

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
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

    }
}
