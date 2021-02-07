using Newtonsoft.Json;
using SloveWare.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DairySolution.Integrations.SolvewareAPI.Services
{
    public class StatusService
    {
        public async Task<List<tblStatus>> GetAllStatusAsync()
        {
            using var client = new HttpClient();
            var res = await client.GetAsync(SolvewareApiHelper.BaseUrl + "Status/GetAllStatus");
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<tblStatus>>(data);

        }
    }
}
