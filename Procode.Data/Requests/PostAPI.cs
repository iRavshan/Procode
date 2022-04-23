using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Requests
{
    public class PostAPI
    {
        public static readonly string GetAll = "post/getall";
        public static readonly string GetById = "post/getbyid?Id=";
        public static readonly string LastContent = "post/lastcontent";
        public static readonly string LastContents = "post/lastcontents?count=";
        public static readonly string Create = "post/create";
    }
}
