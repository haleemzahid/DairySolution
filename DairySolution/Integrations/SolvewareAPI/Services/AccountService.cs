using System.Net.Http;
using System.Threading.Tasks;
using DairySolution.Integrations.SolvewareAPI;
using Newtonsoft.Json;
using DairySolution.Integrations.SolvewareAPI.Model;

namespace DairySolution.Integrations.SolvewareAPI.Services
{
    internal class AccountService
    {
        public static async Task<Contributor> Login(LoginModel model)
        {
            using var client = new HttpClient();
            
            using var res = await client.PostAsJsonAsync(SolvewareApiHelper.BaseUrl + "account/login", model);
            if (!res.IsSuccessStatusCode) return null;
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Contributor>(data);
        }
    }
}
