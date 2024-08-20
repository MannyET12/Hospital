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

        public ActionResult Details(int id)
        {
            var patient = _pdal.GetPatient(id);
            return View(patient);
        }

        [HttpGet, ActionName("Create")]

        public IActionResult Create()
        {
            var vm = new PatientViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePatient(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Patient != null)
                {
                    _pdal.CreatePatient(model.Patient);
                    return RedirectToAction("Index");
                }
            }
            return View("Index",model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(PatientViewModel patient)
        {
            if (patient == null)
            {
                return NotFound();

            }

            if (patient.Patient.ID == 0)
            {
                _pdal.CreatePatient(patient.Patient);

            }
            else
            {
                _pdal.UpdatePatient(patient.Patient);

            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(PatientViewModel patient)
        {
            _pdal.UpdatePatient(patient.Patient);
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {

            _pdal.DeletePatient(id);
            return View();
        }




    }
}
