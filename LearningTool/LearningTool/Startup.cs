using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningTool.Startup))]
namespace LearningTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
