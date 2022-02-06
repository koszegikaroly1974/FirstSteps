using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSteps.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [DisplayName("Kapcsolattartó neve")]
       

        public string ContactName { get; set; }
        [DisplayName("Kapcsolattartó beosztása")]
        public string ContactStatus { get; set; }
        [DisplayName("Kapcsolattartó email címe")]

        public string ContactMail { get; set; }
        [DisplayName("Kapcsolattartó telefonszáma")]
        public string ContactPhone { get; set; }
        [DisplayName("Megjegyzések")]
        public string ContactNotifications { get; set; }
    }
}