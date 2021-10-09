namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Document")]
    public partial class Document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Document()
        {
            abstract_display = new HashSet<abstract_display>();
            author_display = new HashSet<author_display>();
        }

        [Key]
        public int docid { get; set; }

        public int? generalId { get; set; }

        public decimal? score { get; set; }

        public string id { get; set; }

        [StringLength(50)]
        public string journal { get; set; }

        [StringLength(50)]
        public string eissn { get; set; }

        public DateTime? publication_date { get; set; }

        [StringLength(50)]
        public string article_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<abstract_display> abstract_display { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<author_display> author_display { get; set; }

        public virtual General General { get; set; }
    }
}
