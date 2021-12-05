using RestSharp;
using System.Net;

namespace Distro.Portal.WebApplication.Proxies
{
    public abstract class ApiProxyBase
    {
        protected string? BaseUrl { get; set; }

        protected NetworkCredential? Credentials { get; set; }

        protected IEnumerable<string>? Headers { get; set; }

        public void Init(string baseUrl, string username, string password, IEnumerable<string>? headers = null)
        {
            BaseUrl = baseUrl;
            Credentials = new NetworkCredential(username, password);
            Headers = headers;
        }

        public T Call<T,Y>(Method methodType, string location, IEnumerable<Parameter> parameters)
        {
            IRestClient client = new RestClient(BaseUrl);
            IRestRequest request = new RestRequest(location, methodType) { Credentials = Credentials };

            foreach (var paremeter in parameters)
            {
                request.AddParameter(paremeter);
            }

            var response = client.Execute<T>(request);

            if (!response.IsSuccessful)
            {
                throw new ApplicationException($"Failed to call api [{location}] with [{response.ErrorMessage}]");
            }

            return response.Data;
        }
    }
}
