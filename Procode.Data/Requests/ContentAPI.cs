using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Requests
{
    public class ContentAPI
    {
        public static readonly string GetAll = "content/getall";
        public static readonly string GetById = "content/getbyid?Id=";
        public static readonly string LastContent = "content/lastcontent";
        public static readonly string LastContents = "content/lastcontents?count=";
    }
}
