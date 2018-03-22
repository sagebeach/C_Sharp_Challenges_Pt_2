using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChallengePostalCalculatorHelperMethods.Startup))]
namespace ChallengePostalCalculatorHelperMethods
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
