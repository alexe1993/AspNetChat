using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestChat.Startup))]
namespace TestChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
