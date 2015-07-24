using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace AspNetSelfHostDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //StartConsole();
            //StartServiceBase();
            StartTopshelf();
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

                x.SetDescription("This is a demo of a Windows Service using Topshelf.");
                x.SetDisplayName("Self Host Web API Demo");
                x.SetServiceName("AspNetSelfHostDemo");
            });
        }

        static void StartConsole()
        {
            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Console.WriteLine("Web Server is running.");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }

        static void StartServiceBase()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SelfHostServiceBase()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
