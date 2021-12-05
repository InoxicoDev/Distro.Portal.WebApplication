using Distro.Ordering.Domain.Contracts;
using Distro.Ordering.Domain.Entities;

namespace Distro.Portal.WebApplication.Proxies
{
    public class OrderHistoryProxy : ApiProxyBase, IOrderHistoryService
    {
        public OrderHistoryProxy()
        {
            //TODO: ApiProxyDetails populated from config
            string baseUrl = @"https://localhost:8333/";
            string username = "user";
            string password = "pass";
            IEnumerable<string>? headers = new List<string>();

            Init(baseUrl, username, password, headers);
        }

        public IEnumerable<Order> GetOrderHistory(Guid customerId)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("customerId", customerId, RestSharp.ParameterType.QueryString)
            };

            return Call<IEnumerable<Order>, Guid>(RestSharp.Method.POST,
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }
    }
}
