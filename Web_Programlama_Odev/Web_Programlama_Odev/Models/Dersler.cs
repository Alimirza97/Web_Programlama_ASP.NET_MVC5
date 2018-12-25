namespace Web_Programlama_Odev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dersler")]
    public partial class Dersler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dersler()
        {
            Kategoris = new HashSet<Kategori>();
        }

        [Key]
        public int Ders_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ders_Adi { get; set; }

        public int Kategori_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Video { get; set; }

        [Required]
        [StringLength(50)]
        public string Resim { get; set; }

        public TimeSpan Sure { get; set; }

        public int IzlenmeSayisi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategori> Kategoris { get; set; }
    }
}
