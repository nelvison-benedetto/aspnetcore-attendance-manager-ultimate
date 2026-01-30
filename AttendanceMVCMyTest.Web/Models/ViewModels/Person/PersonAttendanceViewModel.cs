using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceMVCMyTest.Web.Models.ViewModels.Person
{
    public class PersonAttendanceViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsAvailable { get; set; }  // true/false/null se non esiste attendance
    }

}