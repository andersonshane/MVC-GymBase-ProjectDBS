using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_GymBase_ProjectDBS.Startup))]
namespace MVC_GymBase_ProjectDBS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
