using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain.Models
{
    public class Feedback
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("AuthorEmail")]
        public string AuthorEmail { get; set; }
    }
}
