using FluentValidation.Results;
using PersonManagementSystem.Business.Abstract;
using PersonManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation;
using PersonManagementSystem.Entities;
using PersonManagementSystem.MVC.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonManagementSystem.MVC.WebUI.Controllers
{
    [Authorize(Roles = "Manager,Secretary")]
    public class PersonRolsController : Controller
    {
        private IRoleService _rolService;
        public PersonRolsController(IRoleService rolService)
        {
            _rolService = rolService;
        }

        public ActionResult Settings()
        {
           
            return View(_rolService.GetAllRole());
            
        }
        [HttpPost]

        public ActionResult Settings(Role Rol)
        {
            RoleValidation loginValidation = new RoleValidation();
            ValidationResult result = loginValidation.Validate(Rol);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(_rolService.GetAllRole());

            }
            _rolService.AddRole(Rol);
            TempData["SuccesAlert"] = "Success add role!";
            return RedirectToAction("Settings");


        }
        public ActionResult DeleteRol(int id)
            {
                var deletedRols = _rolService.GetRole(id);
                _rolService.DeleteRole(deletedRols);
                System.Threading.Thread.Sleep(1000);
                return RedirectToAction("Settings", "PersonRols");

            }
        
    }
}