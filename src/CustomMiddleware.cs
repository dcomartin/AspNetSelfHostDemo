using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace AspNetSelfHostDemo
{
    public class CustomMiddleware : OwinMiddleware
    {
        public CustomMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            context.Response.Headers["MachineName"] = Environment.MachineName;

            await Next.Invoke(context);
        }
    }
}
