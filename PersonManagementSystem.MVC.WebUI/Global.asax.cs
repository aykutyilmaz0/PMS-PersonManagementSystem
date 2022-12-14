using FluentValidation.Mvc;
using PersonManagementSystem.Business.Dependency_Resolvers.Ninject;
using PersonManagementSystem.Business.Dependency_Resolvers.Ninject.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PersonManagementSystem.MVC.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModel()));
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
