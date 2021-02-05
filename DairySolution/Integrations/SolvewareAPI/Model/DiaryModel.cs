using System;
using System.Collections.Generic;
using System.Text;

namespace DairySolution.Integrations.SolvewareAPI.Model
{
   public class DiaryModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Event { get; set; }
        public string Particulars { get; set; }
    }
}
