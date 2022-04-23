using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Home
{
    public class BlogViewModel : ViewModel
    {
        public IEnumerable<Content> Contents { get; set; }
        public IEnumerable<Content> LastContents { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Post> LastPosts { get; set; }
        public string Search { get; set; }
    }
}
