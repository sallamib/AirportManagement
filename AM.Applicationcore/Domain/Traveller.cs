using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain;

public class Traveller : Passenger
{
#nullable disable
    public string HealthInformation { get; set; }
    public string Nationality {  get; set; }
}

//
