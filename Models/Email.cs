using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_gönderme.Models
{
    public class Email
    {
        [Required]
        [Display(Name = "Mail Başlığı")]
        public String baslik { get; set; }
        [Required]
        [Display(Name = "Mail İçeriği")]
        public String icerik { get; set; }
        [Required]
        [Display(Name = "Mail Gönderenin Adı")]
        public String isim { get; set; }
        [Required]
        [Display(Name = "Mail Gönderenin SoyAdı")]
        public String soyisim { get; set; }
        public DateTime MyProperty { get; set; }
    }
}
