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
        public IEnumerable<SongModel> SongModels {get;set;}

        public async Task OnGet()
        {
            
        }
    }
}
