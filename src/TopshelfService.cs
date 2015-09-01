using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace AspNetSelfHostFileServer
{
    public class TopshelfService
    {
        private IDisposable _webapp;

        public void Start()
        {
            _webapp = WebApp.Start<Startup>("http://localhost:8080");
        }

        public void Stop()
        {
            if (_webapp != null)
            {
                _webapp.Dispose();
            }
        }
    }
}
