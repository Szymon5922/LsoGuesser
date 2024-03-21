using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LsoWebApp.Models;
using System.Text.Json;
using System.Reflection;

namespace LsoWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private SongModel _songModel;
        public IndexModel(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        [BindProperty]
        public string[] Quote { get; set; }
        [BindProperty]
        public string Title  => _songModel.Title;
        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("LsoApi");

            using HttpResponseMessage responseMessage = await httpClient.GetAsync("");

            if(responseMessage.IsSuccessStatusCode) 
            {
                using var contentStream = await responseMessage.Content.ReadAsStreamAsync();
                _songModel = await JsonSerializer.DeserializeAsync<SongModel>(contentStream);
            }

            Quote = GetQuote(_songModel);
        }
        private string[] GetQuote(SongModel songModel)
        {
            Random random = new Random();
            int toSkip = random.Next(songModel.Lines.Count - 2);
            return songModel.Lines.Skip(toSkip).Take(2).ToArray();
        }
    }
}
