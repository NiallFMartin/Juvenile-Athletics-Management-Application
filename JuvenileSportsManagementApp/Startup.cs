//Class automatically generated when project was created.
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JuvenileSportsManagementApp.Startup))]
namespace JuvenileSportsManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
