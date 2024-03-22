using LsoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LsoWebApp.Pages
{
    public class GuessSongModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GuessSongModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [BindProperty]
        public GuessSetModel GuessSetModel { get; set; }
        
        [BindProperty]
        public string CorrectTitle => GuessSetModel.Answers.First(a => a.IsCorrect == true).Text;
        

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("LsoApi");

            using HttpResponseMessage responseMessage = await httpClient.GetAsync("SongGuess/");

            if(responseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await responseMessage.Content.ReadAsStreamAsync();
                GuessSetModel = await JsonSerializer.DeserializeAsync<GuessSetModel>(contentStream);
            }
        }
    }
}
