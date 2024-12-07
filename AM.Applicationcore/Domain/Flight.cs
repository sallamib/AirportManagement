using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain;

public class Flight
{
    public string  Destination { get; set; }
#nullable disable 
    public string Departure  { get; set; }
    public DateTime FlightDate { get; set; }
    public int FlightId { get; set; }
    public DateTime EffectiveArrival { get; set;}
    public int EsstimatedDuration { get; set ; }

    public string AirlineLogo { get; set; }
    [Display(Name = "Plane information")]
    public int? PlaneFK { get; set; }
    //prop de navigation 
    [ForeignKey("PlaneFK")]
    public virtual Plane Plane { get; set; }
    public virtual ICollection<Passenger> Passengers { get; set; }  //virtula to activate the lazy loadind virtula prop 


}
