using MVC_Books;
using MVC_Books.Models;
using Newtonsoft.Json;
using System.Text;

namespace Web_Books.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO responseModel { get ; set ; }

        public IHttpClientFactory _httpClient { get; set; }

        public BaseService( IHttpClientFactory httpClient)
        {
            this._httpClient = httpClient;
            this.responseModel = new ResponseDTO();
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("BookAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                HttpResponseMessage httpResponse = null;

                switch (apiRequest.APIType)
                {
                    case StaticDetail.APIType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetail.APIType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetail.APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetail.APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                }
                httpResponse = await client.SendAsync(message);

                var apiContent = await httpResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDTO;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDTO
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false,
                };
                var resp = JsonConvert.SerializeObject(dto);
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(resp);
                return apiResponseDTO;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
