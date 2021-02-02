using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairySolution.Integrations.SolvewareAPI.Model
{
    class Contributor
    {
        public int Id { get; set; }
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public int TblOrderId { get; set; }
        public int TblUserId { get; set; }
    }
}
