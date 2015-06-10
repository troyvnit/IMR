using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMR.Startup))]
namespace IMR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
