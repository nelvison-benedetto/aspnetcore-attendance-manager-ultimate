using AttendanceMVCMyTest.Web.Models.ViewModels.Person;
using AttendanceMVCMyTest.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AttendanceMVCMyTest.Web.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IPersonService _personService;
        public AttendanceController(IPersonService personService)
        {
            this._personService = personService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Day(int dayId)
        {
            var persons = await _personService.GetPersonsByDay(dayId);
            ViewBag.DayId = dayId;
            return View(persons);
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdatePersonAttendanceViewModel model)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(400);
            await _personService.UpdatePersonWithAttendanceAsync(model);
            return RedirectToAction(nameof(Day), new { dayId = model.DayId });

        }

    }
}