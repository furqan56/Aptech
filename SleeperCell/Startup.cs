using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SleeperCell.Startup))]
namespace SleeperCell
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
