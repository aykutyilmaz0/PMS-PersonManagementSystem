using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Abstract
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartment();
        void AddDepartment(Department department);
        void DeleteDepartment(Department department);
        void UpdateDepartment(Department department);
        Department GetDepartment(int DepartmentId);
    }
}
