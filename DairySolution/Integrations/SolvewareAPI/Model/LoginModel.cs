using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DairySolution.Integrations.SolvewareAPI.Model
{
    class LoginModel
    {
        public string OrganizationId { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
