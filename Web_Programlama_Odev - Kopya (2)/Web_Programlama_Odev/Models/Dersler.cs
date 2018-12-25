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
        [MaxLength(50)]
        [Display(Name ="Ders Adý")]
        public string Ders_Adi { get; set; }
        [Display(Name = "Kategori Id")]
        public int Kategori_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Video")]
        public string Video { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Resim")]
        public string Resim { get; set; }

        [Display(Name = "Ýzlenme Sayýsý")]
        public int IzlenmeSayisi { get; set; }

        [Column(TypeName = "date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EklenmeTarihi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategori> Kategoris { get; set; }
    }
}
