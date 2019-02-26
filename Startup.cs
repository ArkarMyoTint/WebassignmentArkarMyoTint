using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StarLight_Ticket.Startup))]
namespace StarLight_Ticket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
