using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using DataModel;
using Exercise.Models;

namespace Exercise
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(UserViewModels), new UserCustomModelBinder());
            CreateMap();
        }

        protected void CreateMap()
        {
            Mapper.CreateMap<UserViewModels, User>();
            Mapper.CreateMap<User, UserViewModels>();
        }
    }
}
