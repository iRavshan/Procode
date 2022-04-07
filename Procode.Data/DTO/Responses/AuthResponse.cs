using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.DTO.Responses
{
    public class AuthResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("succes")]
        public bool Succes { get; set; }

        [JsonProperty("errors")]
        public IEnumerable<string> Errors { get; set; }
    }
}
