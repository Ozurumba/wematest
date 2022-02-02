using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WemcoBank.Data
{
    public class OnBoarding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string age { get; set; }
        public string BusinessName { get; set; }
        public string BusinessRegNumber { get; set; }
        public string Directors { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessAddress { get; set; }
        public string Picture { get; set; }
        public string Signature { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
    }
}
