using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.MVC.Models;

namespace WebApp.MVC.Services
{
    public class EncontrarDivisoresService : IEncontrarDivisoresService
    {
        private readonly HttpClient _httpClient;

        public EncontrarDivisoresService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DivisoresNumero> RetornarDivisoresNumero(int numeroBase)
        {
            UriBuilder builder = new UriBuilder("https://localhost:44375/api/encontrarDivisores/retornarDivisores");
            builder.Query = string.Format("numeroBase={0}", numeroBase);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.GetAsync(builder.Uri);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<DivisoresNumero>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
