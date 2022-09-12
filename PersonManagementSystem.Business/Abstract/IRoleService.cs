using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Abstract
{
    public interface IRoleService
    {
        List<Role> GetAllRole();
        void AddRole(Role role);
        void DeleteRole(Role role);
        void UpdateRole(Role role);
        Role GetRole(int roleId);
    } 
}
