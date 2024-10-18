using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiOnyx.Models
{
    public class User
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        public string Token { get; set; }
        public string CompanyId { get; set; }
    }
}
