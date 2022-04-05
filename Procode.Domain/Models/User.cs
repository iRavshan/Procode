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
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("registeredDateTime")]
        public string RegisteredDateTime { get; set; }

        [JsonProperty("displayEmail")]
        public bool DisplayEmail { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("websiteUri")]
        public string WebsiteUri { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        public string CountOfPosts { get; set; }
        public string CountOfFollowers { get; set; }
        public string CountOfFollowing { get; set; }
    }
}
