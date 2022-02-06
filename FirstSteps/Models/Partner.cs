using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSteps.Models
{
    public class Partner
    {
        [Key]

        public int PartnerId { get; set; }

        [DisplayName("Kapcsolattartó neve")]
        public int ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
        

        [DisplayName("Partner neve")]
        [Required(ErrorMessage ="A Partner név kitöltése kötelező!")]
        public string PartnerName { get; set; }
        [DisplayName("Partner címe")]
        [Required(ErrorMessage ="Parner cím kitöltése kötelező!")]
        public string PartnerAddress { get; set; }
        [DisplayName("Partner adószáma")]
        [Required]
        [Range(80000000,88888888, ErrorMessage ="Az érték 80000000 és 88888888 között kell, hogy legyen!")]
        public int PartnerTaxNumber { get; set; }
        [DisplayName("Megjegyzések")]
        public string PartnerNotifications { get; set; }
    }
}
