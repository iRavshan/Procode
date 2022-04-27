using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain.Models
{
    public class Post
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        [Required(ErrorMessage = "Sarlavhani kiriting")]
        [MinLength(10, ErrorMessage = "Sarlavha kamida 10 ta belgidan iborat bo'lishi kerak")]
        [Display(Name = "Sarlavha")]
        public string Title { get; set; }

        [JsonProperty("shortDescription")]
        [Required(ErrorMessage = "Qisqacha tavsifni kiriting")]
        [MinLength(20, ErrorMessage = "Izoh kamida 20 ta belgidan iborat bo'lishi kerak")]
        [Display(Name = "Qisqacha tavsif")]
        public string ShortDescription { get; set; }

        [JsonProperty("text")]
        [Required(ErrorMessage = "Matnni kiriting")]
        [MinLength(30, ErrorMessage = "Matn kamida 30 ta belgidan iborat bo'lishi kerak")]
        [Display(Name = "Post matni")]
        public string Text { get; set; }

        [JsonProperty("tags")]
        [Display(Name = "Kategoriya")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Faqatgina harflarni qo'llash mumkin")]
        public string Tags { get; set; }

        [JsonProperty("authorUsername")]
        public string AuthorUsername { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("createdTime")]
        public DateTime CreatedTime { get; set; }
    }
}
