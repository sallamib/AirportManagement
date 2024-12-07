using AM.Applicationcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Interfaces;

public interface IServicePlane : IService<Plane>
{
    public IEnumerable<Passenger> GetPassengers(Plane p);

    //- Retourner les vols ordonnés par date de départ des n derniers avions.  
    public IEnumerable<Flight> GetLastNFlights(int n);

    public void DeleteOldPlanes();

}
