using Microsoft.Owin;
using Owin;
using TestChat.Connnection;

[assembly: OwinStartupAttribute(typeof(TestChat.Startup))]
namespace TestChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR<ChatConnection>("/chat");
            app.MapSignalR();
        }
    }
}
