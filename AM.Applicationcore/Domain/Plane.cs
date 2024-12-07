using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain;
    public enum PlaneType {Boing,Airbus}

    public class Plane
    {

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set;}
    //prop de navigation 

    [NotMapped]
    public string Information=> $"Capacity : {Capacity} planetype : {PlaneType}";
    // {
    //get { return "Capacity :" + Capacity.ToString() + " planetype " + PlaneType; }
    //get { return $"Capacity : {Capacity} planetype : {PlaneType}"; }
    //}
    public virtual ICollection<Flight> Flights { get; set;}


    }
