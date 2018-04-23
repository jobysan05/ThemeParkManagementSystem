using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThemeParkManagementSystem.Startup))]
namespace ThemeParkManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
