namespace Web_Programlama_Odev.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uyeler")]
    public partial class Uyeler
    {
        [Key]
        public int UyeId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Email")]
        public string UyeEmail { get; set; }

        [Required]
        [StringLength(20)]
        public string UyeAd { get; set; }

        [Required]
        [StringLength(20)]
        public string UyeSoyad { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Þifre")]
        public string UyeSifre { get; set; }

        [Required]
        [StringLength(20)]
        public string KullaniciAdi { get; set; }

        public int YektiId { get; set; }

        public virtual Yetkiler Yetkiler { get; set; }
    }
}
