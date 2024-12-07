using AM.Applicationcore.Interfaces;
using AM.Applicationcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Services;

public class ServicePlane : Service<Plane> , IServicePlane
{
    public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }

    public IEnumerable<Passenger> GetPassengers(Plane p)
    {
        return p.Flights.SelectMany(f => f.Passengers).AsEnumerable();

    }
    public IList<Passenger> GetPassengers2(int idp)
    {
        return GetById(idp).Flights.SelectMany(f => f.Passengers).ToList();
    }

    public IEnumerable<Flight> GetLastNFlights(int n)
    {
        return GetAll().SelectMany(p => p.Flights).OrderByDescending(f => f.FlightDate).TakeLast(n).ToList();
    }

    //Retourner true si on peut réserver n place à un vol passé en paramètre. 
    public bool CanBookNPlaces(Flight f, int n)
    {
        return f.Passengers.Count() + n <= f.Plane.Capacity;
    }
    //- Supprimer tous les avions dont la date de fabrication a dépassé 10 ans. 
    public void DeleteOldPlanes()
    {
        Delete(p => DateTime.Now.Year - p.ManufactureDate.Year > 10);
    }
}