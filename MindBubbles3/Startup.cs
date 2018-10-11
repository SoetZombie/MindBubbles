using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MindBubbles3.Startup))]
namespace MindBubbles3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
