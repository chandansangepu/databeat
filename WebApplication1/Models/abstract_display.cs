namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class abstract_display
    {
        public int id { get; set; }

        public string abstract_display_name { get; set; }

        public int? docid { get; set; }

        public virtual Document Document { get; set; }
    }
}
