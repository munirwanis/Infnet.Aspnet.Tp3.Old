using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Infnet.Aspnet.Tp3.Startup))]
namespace Infnet.Aspnet.Tp3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
