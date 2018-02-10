using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Homework.Startup))]
namespace MVC_Homework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}