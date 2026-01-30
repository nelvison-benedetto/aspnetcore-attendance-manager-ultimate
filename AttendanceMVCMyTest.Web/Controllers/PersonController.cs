using AttendanceMVCMyTest.Web.Models.ViewModels.Person;
using AttendanceMVCMyTest.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AttendanceMVCMyTest.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            this._personService = personService;
        }

        [HttpGet]  //se non lo metti è cmnq GET di default
        public async Task<ActionResult> Index()  // /Person
        {
            var persons = await _personService.GetAllPersonsAsync();
            return View(persons);
            //Views/{Controller}/{Action}.cshtml
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id) //  /Person/Details/5
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null) return HttpNotFound();
            return View(person);
        }

        [HttpGet]
        public ActionResult Create()  // /Person/Create
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //x security impedische hackers possano usare rotta al posto di utente loggato
        public async Task<ActionResult> Create(CreatePersonAttendanceViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _personService.AddPersonWithAttendanceAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null) return HttpNotFound();
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdatePersonAttendanceViewModel model)
        {
            if (ModelState.IsValid) return View(model);
            await _personService.UpdatePersonWithAttendanceAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null) return HttpNotFound();
            return View(person); // View con messaggio "Sei sicuro?"
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)  //  /Person/Delete/5
        {
            await _personService.DeletePersonCascadeAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}