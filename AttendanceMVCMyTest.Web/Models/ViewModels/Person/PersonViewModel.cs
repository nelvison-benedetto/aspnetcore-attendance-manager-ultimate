using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceMVCMyTest.Web.Models.ViewModels.Person
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //here(x UI), corretto NON AGGIUNGERE AttendanceId, xk quale Attendance (relations 1-*)? se una Person ha 10 Day, poi quale id metti? RISK BUGS!!

    }
}