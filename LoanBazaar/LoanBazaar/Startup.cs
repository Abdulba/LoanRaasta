using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoanBazaar.Startup))]
namespace LoanBazaar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
