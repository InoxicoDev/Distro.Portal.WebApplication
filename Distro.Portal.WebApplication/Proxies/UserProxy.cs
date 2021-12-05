using Distro.Admin.Contracts.Entities;
using Distro.Admin.Contracts.Services;

namespace Distro.Portal.WebApplication.Proxies
{
    public class UserProxy : ApiProxyBase, IUserService
    {
        public UserProxy()
        {
            //TODO: ApiProxyDetails populated from config
            string baseUrl = @"https://localhost:8333/";
            string username = "user";
            string password = "pass";
            IEnumerable<string>? headers = new List<string>();

            Init(baseUrl, username, password, headers);
        }

        public User AddUser(User user)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("user", user, RestSharp.ParameterType.RequestBody)
            };

            return Call<User, User>(RestSharp.Method.POST,
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }

        public User GetUserById(Guid id)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("id", id, RestSharp.ParameterType.QueryString)
            };

            return Call<User, Guid>(RestSharp.Method.POST,
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }

        public User UpdateUser(User user)
        {
            var parms = new List<RestSharp.Parameter>()
            {
                new RestSharp.Parameter("user", user, RestSharp.ParameterType.RequestBody)
            };

            return Call<User, User>(RestSharp.Method.POST,
                System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? String.Empty, parms);
        }
    }
}
