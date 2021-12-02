using Distro.Admin.Contracts.Entities;
using Distro.Admin.Contracts.Services;

namespace Distro.Portal.WebApplication.Proxies
{
    public class CustomerProxy : ICustomerService
    {
        private readonly ICustomerService _customerService;

        public CustomerProxy(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public Customer AddCustomer(Customer customer)
        {
            return _customerService.AddCustomer(customer);
        }

        public Customer GetCustomerById(Guid id)
        {
            return _customerService.GetCustomerById(id);
        }
    }
}
