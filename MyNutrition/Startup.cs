using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyNutrition.Startup))]
namespace MyNutrition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
