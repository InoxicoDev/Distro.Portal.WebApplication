using Distro.Ordering.Domain.Contracts;
using Distro.Ordering.Domain.Entities;

namespace Distro.Portal.WebApplication.Proxies
{
    public class OrderProxy : IOrderService
    {
        private readonly IOrderService _orderService;
        
        public OrderProxy(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Order AddOrder(Order order)
        {
            return _orderService.AddOrder(order);
        }

        public Order? GetOrderById(Guid Id)
        {
            return _orderService.GetOrderById(Id);
        }

        public Order UpdateOrder(Order order)
        {
            return _orderService.UpdateOrder(order);
        }
    }
}
