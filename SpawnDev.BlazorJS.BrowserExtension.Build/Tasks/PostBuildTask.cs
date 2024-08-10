using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SpawnDev.BlazorJS.BrowserExtension.Build.Tasks
{
    public class PostBuildTask : Microsoft.Build.Utilities.Task
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

        [Required]
        public string ExtensionPlatforms { get; set; }

        public string OutputWwwroot { get; set; }

        public bool Verbose { get; set; }

        public override bool Execute()
        {
#if DEBUG
            Log.LogWarning($"**********************************  PostBuildTask.Execute  **********************************");
#endif
            if (DebugSpawnDevBrowserExtensionBuildTasks)
            {
                System.Diagnostics.Debugger.Launch();
            }
            
            OutputWwwroot = Path.GetFullPath(Path.Combine(OutputPath, "wwwroot"));
            PackageContentDir = Path.GetFullPath(PackageContentDir);


           
            return true;
        }
    }
}
