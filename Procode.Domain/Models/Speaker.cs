using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain.Models
{
    public class Speaker
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Firstname")]
        public string Firstname { get; set; }

        [JsonProperty("Lastname")]
        public string Lastname { get; set; }

        [JsonProperty("Job")]
        public string Job { get; set; }

        [JsonProperty("Quote")]
        public string Quote { get; set; }
    }
}
