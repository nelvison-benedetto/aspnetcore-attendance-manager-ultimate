using AttendanceMVCMyTest.Web.Models.Database;
using AttendanceMVCMyTest.Web.Models.ViewModels.User;
using AttendanceMVCMyTest.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AttendanceMVCMyTest.Web.Services.Implementations
{
    public class UserService //: IUserService
    {
        //public async Task<bool> CheckUserPassword(UserLoginModel model)
        //{
        //    using (var db = new AttendanceDbContext())
        //    {
        //        var user = await db.Users
        //            .FirstOrDefaultAsync(u => u.Username == model.Username);
        //        if (user == null) return false;
        //        // qui verifica la password hashata
        //        return user.Password == model.Password; // 🔒 In produzione usa hash!
        //    }
        //}
    }
}