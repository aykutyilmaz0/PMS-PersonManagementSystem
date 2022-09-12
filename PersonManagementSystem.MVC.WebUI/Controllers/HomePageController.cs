using FluentValidation.Results;
using PersonManagementSystem.Business.Abstract;
using PersonManagementSystem.Business.Dependency_Resolvers.Validation;
using PersonManagementSystem.Entities;
using PersonManagementSystem.MVC.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonManagementSystem.MVC.WebUI.Controllers
{
    [Authorize]
    public class HomePageController : Controller
    {
        private IPersonService _personService;
        private IDepartmentService _departmentService;
        private IRoleService _roleService;
        public HomePageController(IPersonService personService, IDepartmentService departmentService, IRoleService roleService)
        {
            _personService = personService;
            _departmentService = departmentService;
            _roleService = roleService;
        }
        public ActionResult Index()
        {
            ViewBag.RoleCount = _roleService.GetAllRole().Count;
            ViewBag.DepartmentCount = _departmentService.GetAllDepartment().Count;
            ViewBag.PersonCount =_personService.GetAllPerson().Count;
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","PersonAccount");
        }

        public ActionResult MyProfile()
        {
            int personId = Convert.ToInt32(Session["PersonId"]);
            var person = _personService.GetPersonDetail(personId);
            return View(person);
        }
        [HttpPost]
        //[Business.Aspect.PostSharp.ValidationAspect.FluentValidationAspect(typeof(PE))]
        public ActionResult MyProfile(Persons persons)
        {
            PersonValidation loginValidation = new PersonValidation();
            ValidationResult result = loginValidation.Validate(persons);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            else
            {

                _personService.UpdatePerson(persons);
                ViewBag.SuccessAlert = "Profil details update successfully!";

                return View(persons);
            }
            
        }
    }
}