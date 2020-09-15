using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admRegistro.Startup))]
namespace admRegistro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
