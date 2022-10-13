using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplication1.Data;
using WebApplication1.Interface;
using WebApplication1.Respositories;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<TravelTourDBContext>();
            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<IEmployeeRepository, EmployeeRespository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}