using PersonManagementSystem.DataAccess.Abstract.Repository;
using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.DataAccess.Abstract
{
    public interface IDepartmentDal:IEntityRepository<Department>
    {
    }
}
