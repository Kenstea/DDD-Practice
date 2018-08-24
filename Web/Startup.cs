using Web;

using Microsoft.Owin;

using Owin;
using Startup = Web.Startup;

[assembly: OwinStartup(typeof(Startup))]

namespace Web
{
    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
