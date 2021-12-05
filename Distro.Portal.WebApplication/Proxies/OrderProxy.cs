using Distro.Ordering.Domain.Contracts;
using Distro.Ordering.Domain.Entities;

namespace Distro.Portal.WebApplication.Proxies
{
    public class OrderProxy : ApiProxyBase, IOrderService
    {
        public OrderProxy()
        {
            //TODO: ApiProxyDetails populated from config
            string baseUrl = @"https://localhost:8333/";
            string username = "user";
            string password = "pass";
            IEnumerable<string>? headers = new List<string>();

            Init(baseUrl, username, password, headers);
        }

        public Order AddOrder(Order order)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("order", order, RestSharp.ParameterType.QueryString)
            };

            return Call<Order, Order>(RestSharp.Method.POST,
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }

        public Order? GetOrderById(Guid id)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("Id", id, RestSharp.ParameterType.QueryString)
            };

            return Call<Order, Guid>(RestSharp.Method.POST,
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }

        public Order UpdateOrder(Order order)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("order", order, RestSharp.ParameterType.RequestBody)
            };

            return Call<Order, Order>(RestSharp.Method.POST,
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }
    }
}
