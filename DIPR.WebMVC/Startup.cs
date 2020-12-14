using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DIPR.WebMVC.Startup))]
namespace DIPR.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
