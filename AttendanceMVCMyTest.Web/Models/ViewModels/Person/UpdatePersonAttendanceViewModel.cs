using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceMVCMyTest.Web.Models.ViewModels.Person
{
    public class UpdatePersonAttendanceViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DayId { get; set; }
        public bool IsAvailable { get; set; }
    }

}