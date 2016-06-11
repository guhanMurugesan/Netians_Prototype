using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndianCitizenService.Startup))]
namespace IndianCitizenService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
