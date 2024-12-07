using AM.Applicationcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Interfaces;

public interface IServiceFlight : IService<Flight>
{
    public IEnumerable<Flight> SortFlights();

}
