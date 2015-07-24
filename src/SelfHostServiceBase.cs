using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace AspNetSelfHostDemo
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
            _webapp?.Dispose();
        }
    }
}
