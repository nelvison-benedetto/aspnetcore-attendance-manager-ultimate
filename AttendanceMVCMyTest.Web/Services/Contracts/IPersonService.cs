using AttendanceMVCMyTest.Web.Models.ViewModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMVCMyTest.Web.Services.Contracts
{
    public interface IPersonService
    {
        Task<IList<PersonViewModel>> GetAllPersonsAsync();
        Task<PersonViewModel> GetPersonByIdAsync(int personId);
        Task<int> AddPersonWithAttendanceAsync(CreatePersonAttendanceViewModel model);
        Task UpdatePersonWithAttendanceAsync(UpdatePersonAttendanceViewModel model);
        Task DeletePersonCascadeAsync(int personId);

    }
}
