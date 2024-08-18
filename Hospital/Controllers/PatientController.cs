using Hospital.Models;
using Hospital.Data;
using Microsoft.AspNetCore.Mvc;
using Hospital.ViewModels;

namespace Hospital.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IPDAL _pdal;

        public PatientController(ApplicationDbContext context, IPDAL pdal)
        {
            _context = context;
            _pdal = pdal;
        }

        public ActionResult Index()
        {
            var patients = _pdal.GetPatients();
            var vm = new PatientViewModel();

            vm.Patients = patients;            

            return View(vm);
        }





    }
}
