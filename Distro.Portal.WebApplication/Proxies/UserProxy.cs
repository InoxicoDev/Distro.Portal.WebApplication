using Distro.Admin.Contracts.Entities;
using Distro.Admin.Contracts.Services;

namespace Distro.Portal.WebApplication.Proxies
{
    public class UserProxy : IUserService
    {
        private readonly IUserService _userService;

        public UserProxy(IUserService customerService)
        {
            _userService = customerService;
        }

        public User AddUser(User user)
        {
            return _userService.AddUser(user);
        }

        public User GetUserById(Guid id)
        {
            return _userService.GetUserById(id);
        }

        public User UpdateUser(User user)
        {
            return _userService.UpdateUser(user);
        }
    }
}
