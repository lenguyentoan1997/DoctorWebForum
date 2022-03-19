using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorsWebForum.Startup))]
namespace DoctorsWebForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
