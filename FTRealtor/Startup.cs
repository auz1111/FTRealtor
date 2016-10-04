using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FTRealtor.Startup))]
namespace FTRealtor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
