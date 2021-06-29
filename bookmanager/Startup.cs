using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bookmanager.Startup))]
namespace bookmanager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
