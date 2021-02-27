using System.Net.Http;
using System.Threading.Tasks;
using DairySolution.Integrations.SolvewareAPI;
using Newtonsoft.Json;
using DairySolution.Integrations.SolvewareAPI.Model;
using SloveWare.Entities;

namespace DairySolution.Integrations.SolvewareAPI.Services
{
    internal class AccountService
    {
        public static async Task<tblContributor> Login(LoginModel model)
        {
            using var client = new HttpClient();
            using var res = await client.PostAsJsonAsync(SolvewareApiHelper.BaseUrl + "Account/Login", model);
            if (!res.IsSuccessStatusCode) return null;
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<tblContributor>(data);
        }
    }
}
