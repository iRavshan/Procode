using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Home
{
    public class IndexViewModel : ViewModel
    {
        public IEnumerable<Content> LastContents { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
    }
}
