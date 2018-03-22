using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChallengeSlotMachine.Startup))]
namespace ChallengeSlotMachine
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
