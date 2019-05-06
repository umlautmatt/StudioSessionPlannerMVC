using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SessionPlanner.WebMVC.Startup))]
namespace SessionPlanner.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
