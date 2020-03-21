using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dev7.EMS.PT.Startup))]
namespace dev7.EMS.PT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
