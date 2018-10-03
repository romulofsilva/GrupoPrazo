using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrupoPrazo.Web.Startup))]
namespace GrupoPrazo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
