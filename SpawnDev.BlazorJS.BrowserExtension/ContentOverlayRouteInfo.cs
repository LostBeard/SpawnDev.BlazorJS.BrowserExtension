using System.Text.RegularExpressions;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    public class ContentOverlayRouteInfo
    {
        public string Location { get; init; }
        public Type ContentComponentType { get; init; }
        public Match Match { get; init; }
        public ContentLocationAttribute ContentLocationAttribute { get; init; }
        public ContentOverlayRouteInfo(string location, Type contentComponentType, Match match, ContentLocationAttribute contentLocationAttribute)
        {
            Location = location;
            ContentLocationAttribute = contentLocationAttribute;
            ContentComponentType = contentComponentType;
            Match = match;
        }
    }
}
