using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.ViewModels.Home
{
    public class ContactViewModel : ViewModel
    {
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
    }
}
