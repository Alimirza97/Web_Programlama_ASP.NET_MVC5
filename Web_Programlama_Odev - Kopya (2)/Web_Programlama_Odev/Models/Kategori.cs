namespace Web_Programlama_Odev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kategori")]
    public partial class Kategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategori()
        {
            Derslers = new HashSet<Dersler>();
        }

        [Key]
        public int Kategori_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Kategori Ad�")]
        public string Kategori_Adi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dersler> Derslers { get; set; }
    }
}
