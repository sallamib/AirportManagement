 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Passenger
    {
        [Display(Name ="Date valide")]
        [DataType(DataType.Date)]//Calender 
        public DateTime BirthDate { get; set; }
#nullable disable
        [Key]
        [StringLength(7)] 
        public string PassportNumber { get; set; }
        //type complexe 
        public FullName FullName { get; set; }

        //[EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string  EmailAddress { get; set; }
        public string  TellNumber { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }





    }
}
