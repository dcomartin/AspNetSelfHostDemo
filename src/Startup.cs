using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace AspNetSelfHostFileServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Adding to the pipeline with our own middleware
            app.Use(async (context, next) =>
            {
                // Add Header
                context.Response.Headers["Product"] = "Web Api Self Host";

                // Call next middleware
                await next.Invoke();
            });
            
            // Custom Middleare
            app.Use(typeof(CustomMiddleware));
            
            // Web Api
            app.UseWebApi(config);

            // Fik
            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true,
                DefaultFilesOptions = { DefaultFileNames = {"index.html"}},
                FileSystem = new PhysicalFileSystem(System.Configuration.ConfigurationManager.AppSettings["location"]),
                StaticFileOptions = { ContentTypeProvider = new CustomContentTypeProvider() }
            };

            app.UseFileServer(options);
        }
    }
}
