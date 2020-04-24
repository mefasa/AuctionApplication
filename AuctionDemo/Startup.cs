using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuctionDemo.Startup))]
namespace AuctionDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
