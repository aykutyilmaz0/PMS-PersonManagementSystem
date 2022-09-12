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
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public void AddRole(Role role)
        {
            _roleDal.AddOperation(role);
        }

        public void DeleteRole(Role role)
        {
            _roleDal.DeleteOperation(role);
        }

        public List<Role> GetAllRole()
        {
            return _roleDal.ListOperation();
        }

        public Role GetRole(int roleId)
        {
           return  _roleDal.GetPerson(x=>x.RoleId == roleId);
        }

        public void UpdateRole(Role role)
        {
            _roleDal.UpdateOperation(role);
        }
    }

}
