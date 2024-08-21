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
            vm.Patient = new Patient
            {
                CreationDate = DateTime.Now
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePatient(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Patient.ID == 0)
                {
                    _pdal.CreatePatient(model.Patient);
                    return RedirectToAction("Index");
                }
                else
                {
                    _pdal.UpdatePatient(model.Patient);
                    return RedirectToAction("Index");
                }
            }
            return View("Create", model);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            _pdal.GetPatient(id);
            var vm = new PatientViewModel()
            {
                Patient = _pdal.GetPatient(id)
            };


            return View("Create", vm);
        }

        public ActionResult Delete(int id)
        {

            _pdal.DeletePatient(id);
            return RedirectToAction(nameof(Index));
        }




    }
}
