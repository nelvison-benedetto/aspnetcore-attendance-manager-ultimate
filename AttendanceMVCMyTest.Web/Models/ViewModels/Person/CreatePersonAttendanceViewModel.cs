using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceMVCMyTest.Web.Models.ViewModels.Person
{
    public class CreatePersonAttendanceViewModel
    {
        //questa la utilizzi x le CRUD(per passare da una tabs all'altra & aggiornare db), NON UTILIZZATA IN UI, quindi necessarie foreign keys!
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isAvaible { get; set; }
        public int dayId { get; set; }

    }
}