using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PreporukaJela.Startup))]
namespace PreporukaJela
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
