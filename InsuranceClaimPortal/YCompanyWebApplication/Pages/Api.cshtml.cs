using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YCompanyWebApplication.Pages
{
    [Authorize]
    public class ApiModel : PageModel
    {
        public string Data { get; set; }

        private IHttpClientFactory HttpClientFactory { get; }

        private IConfiguration _configuration;

        public ApiModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            HttpClientFactory = httpClientFactory;
            _configuration = configuration;
            Data = string.Empty;
        }
        public async Task OnGet()
        {
            //using var httpClient = HttpClientFactory.CreateClient("PaymentsAPI");
            using var httpClient = HttpClientFactory.CreateClient("ThirdPartyAPI");


            // get the access token from the cookie and add it to the default request headers. the save token = true is helpful here as we have the token

            //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await HttpContext.GetTokenAsync("access_token"));
            //Data = await httpClient.GetStringAsync("/WeatherForecast");

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await HttpContext.GetTokenAsync("access_token"));
            Data = await httpClient.GetStringAsync("/ThirdParty");

        }
    }
}
