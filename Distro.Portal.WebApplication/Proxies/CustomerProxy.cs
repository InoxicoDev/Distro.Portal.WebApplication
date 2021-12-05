using Distro.Admin.Contracts.Entities;
using Distro.Admin.Contracts.Services;

namespace Distro.Portal.WebApplication.Proxies
{
    public class CustomerProxy : ApiProxyBase, ICustomerService
    {
        public CustomerProxy()
        {
            //TODO: ApiProxyDetails populated from config
            string baseUrl = @"https://localhost:8333/";
            string username = "user";
            string password = "pass";
            IEnumerable<string>? headers = new List<string>();

            Init(baseUrl, username, password, headers);
        }

        public Customer AddCustomer(Customer customer)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("customer", customer, RestSharp.ParameterType.RequestBody)
            };

            return Call<Customer, Customer>(RestSharp.Method.POST, 
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }

        public Customer GetCustomerById(Guid id)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("id", id, RestSharp.ParameterType.QueryString)
            };

            return Call<Customer, Guid>(RestSharp.Method.GET,
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }
    }
}
