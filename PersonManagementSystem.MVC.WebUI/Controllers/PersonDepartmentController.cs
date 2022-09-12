using FluentValidation.Results;
using PersonManagementSystem.Business.Abstract;
using PersonManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation;
using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonManagementSystem.MVC.WebUI.Controllers
{
    [Authorize(Roles = "Manager,Secretary")]
    public class PersonDepartmentController : Controller
    {
        private IDepartmentService _departmentService;
        public PersonDepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;       
        }
        public ActionResult Index()
        {
            return View(_departmentService.GetAllDepartment());
        }
        public ActionResult DeleteDepartment(int id)
        {
            var getdepartment = _departmentService.GetDepartment(id);
            _departmentService.DeleteDepartment(getdepartment);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }
        public ActionResult AddDepartment(Department department)
        {
            DepartmentValidation loginValidation = new DepartmentValidation();
            ValidationResult result = loginValidation.Validate(department);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return RedirectToAction("Index");

            }
            _departmentService.AddDepartment(department);
            TempData["SuccesAlert"] = "Success add department!";
            return RedirectToAction("Index");
            
        }
    }
}