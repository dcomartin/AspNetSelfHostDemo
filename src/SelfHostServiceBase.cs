using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace AspNetSelfHostFileServer
{
    public partial class SelfHostServiceBase : ServiceBase
    {
        private IDisposable _webapp;

        public SelfHostServiceBase()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _webapp = WebApp.Start<Startup>("http://localhost:8080");
        }

        protected override void OnStop()
        {
            if(_webapp !=null)
            {
            _webapp.Dispose();
            }
        }
    }
}
