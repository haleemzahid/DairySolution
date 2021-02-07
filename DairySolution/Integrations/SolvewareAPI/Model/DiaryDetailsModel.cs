using System;
using System.Collections.Generic;
using System.Text;

namespace DairySolution.Integrations.SolvewareAPI.Model
{
   public class DiaryDetailsModel
    {
        public int Id { get; set; }
        public string Particulars { get; set; }
        public bool IsHandsOn { get; set; }
        public int tblDiaryId { get; set; }
        
        public string EventName { get; set; }
        public int tblEventId { get; set; }
        public int tblStatusId { get; set; }
        public string StatusName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
