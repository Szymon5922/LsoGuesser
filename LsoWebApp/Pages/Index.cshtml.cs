using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LsoWebApp.Models;
using System.Text.Json;

namespace LsoWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IndexModel(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        [BindProperty]
        public SongModel SongModel {get;set;}

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("LsoApi");

            using HttpResponseMessage responseMessage = await httpClient.GetAsync("");

            if(responseMessage.IsSuccessStatusCode) 
            {
                using var contentStream = await responseMessage.Content.ReadAsStreamAsync();
                SongModel = await JsonSerializer.DeserializeAsync<SongModel>(contentStream);
            }
        }
    }
}
