using AttendanceMVCMyTest.Web.Models.Database;
using AttendanceMVCMyTest.Web.Models.ViewModels.Person;
using AttendanceMVCMyTest.Web.Services.Contracts;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AttendanceMVCMyTest.Web.Services.Implementations
{
    public class PersonService : IPersonService
    {

        public async Task<IList<PersonViewModel>> GetAllPersonsAsync() {
            using (var db = new AttendanceDbContext()) {
                db.Database.Log = msg => Console.WriteLine(msg);
                return await db.Person
                    .Select(p => new PersonViewModel
                    {
                        PersonId = p.PersonId,
                        FirstName = p.FirstName,
                        LastName = p.LastName
                    }).ToListAsync();  //ok
            }
        }

        public async Task<IList<PersonAttendanceViewModel>> GetPersonsByDay(int dayId)
        {
            using (var db = new AttendanceDbContext())
            {
                db.Database.Log = msg => Console.WriteLine(msg);
                //return await db.Person 
                return await db.Person
                    .Select(p => new PersonAttendanceViewModel
                    {
                        PersonId = p.PersonId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        IsAvailable = p.Attendance
                    .Where(a => a.DayId == dayId)
                    .Select(a => (bool?)a.IsAvailable)
                    .FirstOrDefault()
                    })
                    .ToListAsync();
            }
        }

        public async Task<PersonViewModel> GetPersonByIdAsync(int personId) {
            using (var db = new AttendanceDbContext()) {
                db.Database.Log = msg => Console.WriteLine(msg);
                return await db.Person
                    .Where(p => p.PersonId == personId)
                    .Select(p => new PersonViewModel {
                        PersonId = p.PersonId,
                        FirstName = p.FirstName,
                        LastName = p.LastName
                    }).FirstOrDefaultAsync();  //ok
            }
        }


        public async Task<int> AddPersonWithAttendanceAsync(CreatePersonAttendanceViewModel model) {
            using (var db = new AttendanceDbContext()) { 
                db.Database.Log = msg => Console.WriteLine(msg);
                //trovo existing day(se esiste)
                var day = await db.Day
                    .FirstOrDefaultAsync(d => d.DayId == model.dayId);
                if (day == null) throw new Exception("day not found");
                //creo nuova person
                var person = new Person { FirstName = model.FirstName, LastName = model.LastName };
                //creo nuova attendance
                var attendance = new Attendance { IsAvailable = model.isAvaible, Day = day, Person = person };
                db.Person.Add(person);  //ok
                await db.SaveChangesAsync();
                return person.PersonId;
            }
        }

        public async Task UpdatePersonWithAttendanceAsync(UpdatePersonAttendanceViewModel model) {
            using (var db = new AttendanceDbContext()) { 
                db.Database.Log = msg => Console.WriteLine(msg);

                var person = await db.Person
                    .Include(p => p.Attendance) //FONDAMENTALE "Quando carichi la Person, carica anche tutte le Attendance collegate"
                    .FirstOrDefaultAsync(p => p.PersonId == model.PersonId);
                if (person == null) throw new Exception("person non trovata");
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                var attendance = person.Attendance
                    .FirstOrDefault( a=> a.DayId == model.DayId );
                if (attendance != null) { attendance.IsAvailable = model.IsAvailable; }
                else {
                    attendance = new Attendance
                    {
                        PersonId = model.PersonId,
                        DayId = model.DayId,
                        IsAvailable = model.IsAvailable,
                    };
                    person.Attendance.Add(attendance);
                }
                await db.SaveChangesAsync();
            }
        }

        public async Task DeletePersonCascadeAsync(int personId) {
            using (var db = new AttendanceDbContext()) { 
                db.Database.Log = msg => Console.WriteLine(msg);

                var person = await db.Person
                    .FirstOrDefaultAsync( p=> p.PersonId == personId );
                if (person == null) return;
                db.Person.Remove(person);  //ok
                await db.SaveChangesAsync();
            }
        }


    }
}