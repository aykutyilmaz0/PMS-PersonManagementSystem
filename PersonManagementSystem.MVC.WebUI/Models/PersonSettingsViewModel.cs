using PersonManagementSystem.Entities;
using PersonManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonManagementSystem.MVC.WebUI.Models
{
    public class PersonSettingsViewModel
    {
        public List<PersonelDetails> Details { get; set; }
        public List<Role> Roles { get; set; }
        public List<Department> Departmens { get; set; }
        public Persons Person { get; set; }
        public string RoleId { get; set; }
        public string DepartmentId { get; set; }
    }
}