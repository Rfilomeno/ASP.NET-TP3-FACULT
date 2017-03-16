using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TP3.Startup))]
namespace TP3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
