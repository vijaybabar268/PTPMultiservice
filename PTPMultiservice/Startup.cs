using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTPMultiservice.Startup))]
namespace PTPMultiservice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
