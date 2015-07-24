using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AspNetSelfHostDemo;

namespace WindowsServiceBase
{
    public partial class SelfHostServiceBase : ServiceBase
    {
        public SelfHostServiceBase()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:8080");
        }

        protected override void OnStop()
        {

        }
    }
}
