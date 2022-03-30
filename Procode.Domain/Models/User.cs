using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain.Models
{
    public class User
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string CountOfPosts { get; set; }
        public string CountOfFollowers { get; set; }
        public string CountOfFollowing { get; set; }
    }
}
