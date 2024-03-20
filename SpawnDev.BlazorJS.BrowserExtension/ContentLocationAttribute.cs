namespace SpawnDev.BlazorJS.BrowserExtension
{
    public class ContentLocationAttribute : Attribute
    {
        /// <summary>
        /// ContentLocationAttribute name
        /// </summary>
        public string Name { get; private set; } = "";
        /// <summary>
        /// Higher weights will be used before lower
        /// </summary>
        public int Weight { get; private set; } = 0;
        /// <summary>
        /// The pattern that will be used to vaildate the route
        /// </summary>
        public string LocationRegexPattern { get; private set; }
        public ContentLocationAttribute(string locationRegexPattern, int weight = 0, string name = "")
        {
            Name = name ?? "";
            LocationRegexPattern = locationRegexPattern;
            Weight = weight;
        }
    }
}
