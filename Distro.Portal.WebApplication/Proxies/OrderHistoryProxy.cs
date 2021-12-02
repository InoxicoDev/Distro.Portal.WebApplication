using Distro.Ordering.Domain.Contracts;
using Distro.Ordering.Domain.Entities;

namespace Distro.Portal.WebApplication.Proxies
{
    public class OrderHistoryProxy : IOrderHistoryService
    {
        private readonly IOrderHistoryService _orderHistoryService;
        
        public OrderHistoryProxy(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }

        public IEnumerable<Order> GetOrderHistory(Guid customerId)
        {
            return _orderHistoryService.GetOrderHistory(customerId);
        }
    }
}
