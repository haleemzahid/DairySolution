﻿using DairySolution.Integrations.SolvewareAPI.Model;
using Newtonsoft.Json;
using SloveWare.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DairySolution.Integrations.SolvewareAPI.Services
{
   public class DiaryService
    {

        public async Task<bool> InsertDiary(tblDiaryDetails model)
        {
            using var client = new HttpClient();
            using var res = await client.PostAsJsonAsync(SolvewareApiHelper.BaseUrl + "Diary/AddDiary", model);
            if (!res.IsSuccessStatusCode) return false;
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();
            return true;

        }
        public async Task<List<tblDiaryDetails>> GetAllPostedDiaryAsync()
        {
            using var client = new HttpClient();
            var res = await client.GetAsync(SolvewareApiHelper.BaseUrl + "Diary/GetAllPostedDiaries");
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<tblDiaryDetails>>(data);

        }
        public async Task<List<tblDiary>> GetAllDiaryAsync()
        {
            using var client = new HttpClient();
            var res= await client.GetAsync(SolvewareApiHelper.BaseUrl + "Diary/GetAllDiaries");
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<List<tblDiary>>(data);

        }



    }
}
