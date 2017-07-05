using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shipping.Startup))]
namespace Shipping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
