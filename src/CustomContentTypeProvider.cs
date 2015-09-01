using Microsoft.Owin.StaticFiles.ContentTypes;

namespace AspNetSelfHostFileServer
{
    public class CustomContentTypeProvider : FileExtensionContentTypeProvider
    {
        public CustomContentTypeProvider()
        {
            Mappings.Add(".json", "application/json");
            Mappings.Add(".log", "application/text");
        }
    }
}