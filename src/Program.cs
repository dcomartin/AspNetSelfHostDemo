using System;
using System.ServiceProcess;
using Topshelf;

namespace AspNetSelfHostFileServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Option to run as interactive or in the service.
            if (Environment.UserInteractive) {
                StartTopshelf();
            }
            else
            { 
                StartServiceBase(); 
            }
        }

        static void StartTopshelf()
        {
            HostFactory.Run(x =>
            {
                x.Service<TopshelfService>(s =>
                {
                    s.ConstructUsing(name => new TopshelfService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("This is a FileServer.");
                x.SetDisplayName("WebAPIFileServer");
                x.SetServiceName("WebAPIFileServer");
            });
        }
        static void StartServiceBase()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] {
                new SelfHostServiceBase()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}