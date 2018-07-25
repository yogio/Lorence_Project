using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lorence_Project.Startup))]
namespace Lorence_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
