using AM.Applicationcore.Domain;
using AM.Applicationcore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.Web.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight serviceFlight;
        IServicePlane planeService;
        public FlightController(IServiceFlight serviceFlight, IServicePlane planeService)
        {
            this.serviceFlight = serviceFlight;
            this.planeService = planeService;
        }
        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(serviceFlight.GetAll().ToList());
            else
                return View(serviceFlight.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());
        }

        public ActionResult IndexWithPartialview()
        {
            return View(serviceFlight.GetAll().ToList());
        }


        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {

            return View(serviceFlight.GetById(id));
        }

        // GET: FlightController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Planes = new SelectList(planeService.GetAll().ToList(),
            "PlaneId", "Capacity");
            return View();

        }

        // POST: FlightController/Create
        //code under the button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight, IFormFile AirLineLogo) //Use IFOrmCollection whan i dont know the model
        {
            try
            {
                if (AirLineLogo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", AirLineLogo.FileName);//creation du dossier uploads
                    Stream stream = new FileStream(path, FileMode.Create); AirLineLogo.CopyTo(stream);//ajout non du dossier uploads
                    flight.AirlineLogo = AirLineLogo.FileName;//non du logo dans la base de donnees
                }
                serviceFlight.Add(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    

        

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            //edit 
            ViewBag.myplanes = new SelectList(planeService.GetAll().ToList(),
            "PlaneId", "Information");
            return View(serviceFlight.GetById(id));
        }
        public ActionResult Sort()
        {
            return View("Index", serviceFlight.SortFlights());
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight flight)
        {
            try
            {
                flight.FlightId = id;
                serviceFlight.Update(flight);
                serviceFlight.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(serviceFlight.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight flight)
        {
            try
            {
                flight.FlightId = id;
                serviceFlight.Delete(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    

}
