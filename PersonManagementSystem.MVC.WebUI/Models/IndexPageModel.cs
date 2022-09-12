using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonManagementSystem.MVC.WebUI.Models
{
    public class IndexPageModel
    {
        public List<Role> Rols { get; set; }
        public List<Department> Departments { get; set; }
        public List<Persons> Persons { get; set; }
    }
}