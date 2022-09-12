using FluentValidation.Results;
using PersonManagementSystem.Business.Abstract;
using PersonManagementSystem.Business.Dependency_Resolvers.Validation;
using PersonManagementSystem.Entities;
using PersonManagementSystem.Entities.Concrete.ComplexType;
using PersonManagementSystem.MVC.WebUI.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonManagementSystem.MVC.WebUI.Controllers
{
    [Authorize(Roles = "Manager,Secretary")]
    public class PersonSettingsController : Controller
    {
        private IPersonService _personService;
        private IRoleService _roleService;
        private IDepartmentService _departmentService;
        PersonSettingsViewModel mymodel = new PersonSettingsViewModel();
        List<SelectListItem> rols = new List<SelectListItem>();
        List<SelectListItem> department = new List<SelectListItem>();

        public PersonSettingsController(IPersonService personService, IRoleService roleService, IDepartmentService departmentService)
        {
            _personService = personService;
            _roleService = roleService;
            _departmentService = departmentService;
        }
        private void ListOperation()
        {
            mymodel.Roles = _roleService.GetAllRole();
            mymodel.Departmens = _departmentService.GetAllDepartment();
           
            foreach (var item in mymodel.Roles)
            {
                rols.Add(new SelectListItem { Text = item.RoleName, Value = item.RoleId.ToString() });
            }
            foreach (var item in mymodel.Departmens)
            {
                department.Add(new SelectListItem { Text = item.DepartmentName, Value = item.DepartmentId.ToString() });

            }
        }
        public ActionResult EditPerson()
        {
            mymodel.Details = _personService.GetPersonelDetail();
            ListOperation();
            return View(mymodel);
        }

        public ActionResult AddPerson(PersonSettingsViewModel viewpersonmodel)
        {
            viewpersonmodel.Person.DepartmentId = Convert.ToInt32(viewpersonmodel.DepartmentId);
            viewpersonmodel.Person.RoleId = Convert.ToInt32(viewpersonmodel.RoleId);

            PersonValidation loginValidation = new PersonValidation();
            ValidationResult result = loginValidation.Validate(viewpersonmodel.Person);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return RedirectToAction("EditPerson");
                
            }
            else
            {

            _personService.AddPerson(viewpersonmodel.Person);
            TempData["Success"] = "Successfully add Person!";
            return RedirectToAction("EditPerson");
            }

        }

        public ActionResult DeletePerson(int personıd)
        {
            var deletedPerson = _personService.GetPersonDetail(personıd);
            _personService.DeletePerson(deletedPerson);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("EditPerson");
        }

        [HttpPost]
        public ActionResult PersonUpdateView(int id)
        {
            ListOperation();
            mymodel.Person = _personService.GetPersonDetail(id);
            mymodel.RoleId = mymodel.Person.RoleId.ToString();
            mymodel.DepartmentId = mymodel.Person.DepartmentId.ToString();
            return PartialView(mymodel);
        }

        public ActionResult PersonUpdateViewUpdate(PersonSettingsViewModel mymodelUpdated)
        {
            
            _personService.UpdatePerson(mymodelUpdated.Person);
            
            TempData["merih"] = "Updated person!";
            return RedirectToAction("EditPerson");
        }




    }
}