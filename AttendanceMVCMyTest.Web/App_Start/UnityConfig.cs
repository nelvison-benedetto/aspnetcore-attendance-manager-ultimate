using AttendanceMVCMyTest.Web.Services.Contracts;
using AttendanceMVCMyTest.Web.Services.Implementations;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AttendanceMVCMyTest.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IPersonService, PersonService>();
            //container.RegisterType<IDayService, DayService>();
            //container.RegisterType<IAttendanceService, AttendanceService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}