using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain.Models
{
    public class Content
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AuthorFirstname")]
        public string AuthorFirstname { get; set; }

        [JsonProperty("AuthorLastname")]
        public string AuthorLastname { get; set; }

        [JsonProperty("ShortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Tag")]
        public string Tag { get; set; }

        [JsonProperty("YouTubeVideoId")]
        public string YoutubeVideoId { get; set; }

        [JsonProperty("GitUrl")]
        public string GitUrl { get; set; }

        [JsonProperty("ThumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("VideoUrl")]
        public string VideoUrl { get; set; }

        [JsonProperty("CreateTime")]
        public DateTime CreateTime { get; set; }
    }
}
