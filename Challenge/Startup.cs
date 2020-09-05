using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Challenge.Startup))]
namespace Challenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
