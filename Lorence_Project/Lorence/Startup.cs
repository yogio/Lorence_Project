using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lorence.Startup))]
namespace Lorence
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
