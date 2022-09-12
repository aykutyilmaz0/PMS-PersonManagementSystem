using PersonManagementSystem.Business.Abstract;
using PersonManagementSystem.DataAccess.Abstract;
using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Concrete.Managers
{
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public void AddDepartment(Department department)
        {
            _departmentDal.AddOperation(department);
        }

        public void DeleteDepartment(Department department)
        {
            _departmentDal.DeleteOperation(department);
        }

        public List<Department> GetAllDepartment()
        {
            return _departmentDal.ListOperation();
        }

        public Department GetDepartment(int DepartmentId)
        {
            return _departmentDal.GetPerson(x=>x.DepartmentId == DepartmentId);
        }

        public void UpdateDepartment(Department department)
        {
            _departmentDal.UpdateOperation(department);
        }
    }
}
