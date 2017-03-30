using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContainerManagementSystem.Startup))]
namespace ContainerManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
