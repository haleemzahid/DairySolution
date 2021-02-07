using Newtonsoft.Json;
using SloveWare.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DairySolution.Integrations.SolvewareAPI.Services
{
    public class EventService
    {



        public async Task<List<tblEvent>> GetAllEvent()
        {
            using var client = new HttpClient();
            var res = await client.GetAsync(SolvewareApiHelper.BaseUrl + "Event/GetAllEvent");
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<tblEvent>>(data);

        }
    }
}
