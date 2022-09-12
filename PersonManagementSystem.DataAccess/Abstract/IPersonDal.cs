using PersonManagementSystem.DataAccess.Abstract.Repository;
using PersonManagementSystem.Entities;
using PersonManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.DataAccess.Abstract
{
    public interface IPersonDal:IEntityRepository<Persons>
    {
        List<PersonRole> GetPersonRole(string username);
        List<PersonelDetails> GetPersonDetails();
    }
}
