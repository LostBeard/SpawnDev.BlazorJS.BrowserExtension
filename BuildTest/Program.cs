// See https://aka.ms/new-console-template for more information
using SpawnDev.BlazorJS.BrowserExtension.Build.Tasks;

Console.WriteLine("Running PostPublishTask test");

var testProjectOutputPath = @"D:\users\tj\Projects\SpawnDev.BlazorJS.BrowserExtension\SpawnDev.BlazorJS.BrowserExtension\Tolerador\bin\PublishDebug";
var task = new PostPublishTask
{
    PublishMode = true,
    OutputPath = testProjectOutputPath,
    DryRun = true, 
};
task.Execute();
