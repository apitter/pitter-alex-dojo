using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.ServiceClients
{
    public abstract class ServiceClient
    {
        private readonly HttpClient _httpClient;

        protected ServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        protected async Task<T> CallService<T>(string uri, HttpMethod httpMethod)
        {
            var serviceName = GetType().Name;

            try
            {
                var request = new HttpRequestMessage(httpMethod, uri);

                Trace.TraceInformation($"Call {serviceName}; url {uri}");

                var response = await _httpClient.SendAsync(request);
                var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                // this doesn't quite work as api returns 200 even if 404?
                if (!response.IsSuccessStatusCode)
                {
                    switch (response.StatusCode)
                    {
                        default:
                            throw new InvalidOperationException($"{response.ReasonPhrase} {responseContent}");
                    }
                }

                return DeserializeResult<T>(responseContent);
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Call {serviceName} to url {uri} failed: {ex.Message}");
                throw;
            }
        }

        private static T DeserializeResult<T>(string json) =>
            JsonConvert.DeserializeObject<T>(json,
                new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });

    }
}
