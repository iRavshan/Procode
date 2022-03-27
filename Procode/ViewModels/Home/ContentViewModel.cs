using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Home
{
    public class ContentViewModel : ViewModel
    {
        public Content Content { get; set; } 
        public IEnumerable<Content> LastContents { get; set; }

        public string Search { get; set; }
    }
}
