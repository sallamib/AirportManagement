using AM.Applicationcore.Domain;
using AM.Applicationcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Services;

public class ServicveFlight : Service<Flight>, IServiceFlight
{
    public ServicveFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

      


    }
    //implemetation des methodes avance 
    public IEnumerable<Flight> SortFlights()
    {
        return GetAll().OrderByDescending(f => f.FlightDate);
    }
}
