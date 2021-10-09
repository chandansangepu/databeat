using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GeneralObject
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public decimal maxScore { get; set; }
        public DocumentObject[] docs { get; set; }
    }
        public class Response
        {
            public GeneralObject response { get; set; }
        }
}