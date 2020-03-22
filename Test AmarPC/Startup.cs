using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_AmarPC.Startup))]
namespace Test_AmarPC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
