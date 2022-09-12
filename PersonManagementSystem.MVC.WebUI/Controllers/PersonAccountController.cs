using FluentValidation.Results;
using PersonManagementSystem.Business.Abstract;
using PersonManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation;
using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonManagementSystem.MVC.WebUI.Controllers
{
    [AllowAnonymous]
    public class PersonAccountController : Controller
    {
        private IPersonService _personService;
        public PersonAccountController(IPersonService personService)
        {
            _personService = personService;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password,Persons person)
        {
            
            LoginValidation loginValidation = new LoginValidation();
            ValidationResult result = loginValidation.Validate(person);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            var checkedperson = _personService.GetPerson(username, password);
            if (checkedperson != null)
            {
                var rolperson = _personService.GetPersonRole(username);
                Session["PersonId"] = rolperson[0].PersonId;
                string personrol = rolperson[0].RoleName;
                string persontype = personrol + " " + checkedperson.FirstName + " " + checkedperson.LastName;
                FormsAuthentication.SetAuthCookie(persontype,false);
                return RedirectToAction("Index","HomePage");
            }
            ViewBag.Alert = "Username of password is invalid";
            return View();
        }
        
    }
}