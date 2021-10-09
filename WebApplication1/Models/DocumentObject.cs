using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DocumentObject
    {
        public string id { get; set; }
        public string journal { get; set; }
        public string eissn { get; set; }

        public string article_type { get; set; }
        public DateTime publication_date { get; set; }
        public string[] author_display { get; set; }
        public string[] @abstract { get; set; }
        public string title_display { get; set; }
        public decimal score { get; set; }
    }
}