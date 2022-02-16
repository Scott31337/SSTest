using Funq;
using ServiceStack;
using SSTest.ServiceInterface;

namespace SSTest
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyWindowService
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("SSTest", typeof(AppHost).Assembly) { } //We will manually add routes.

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            RegisterService<MyServices>();
            Routes.Add(typeof(SSTest.ServiceModel.BillGETRequest), "/Bills/{BillID}", "GET", "Retrieves a bill of materials record.", "");
            Routes.Add(typeof(SSTest.ServiceModel.BillPOSTRequest), "/Bills", "POST", "Creates a bill of materials record.", "");
        }
    }
}
