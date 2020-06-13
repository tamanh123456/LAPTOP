using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAPTOP.Startup))]
namespace LAPTOP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
