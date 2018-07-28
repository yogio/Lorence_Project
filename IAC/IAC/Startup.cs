using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IAC.Startup))]
namespace IAC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
