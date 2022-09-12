using PersonManagementSystem.DataAccess.Abstract;
using PersonManagementSystem.Entities;
using PersonManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Persons, PersonManagementContext>, IPersonDal
    {
        public List<PersonelDetails> GetPersonDetails()
        {
            using (PersonManagementContext context = new PersonManagementContext())
            {
                var result = from p in context.Persons
                             join c in context.Role on p.RoleId equals c.RoleId
                             join z in context.Department on p.DepartmentId equals z.DepartmentId
                             select new PersonelDetails
                             {
                                 PersonId = p.PersonId,
                                 RoleName = c.RoleName,
                                 FirstName = p.FirstName,
                                 LastName = p.LastName,
                                 DepartmentName = z.DepartmentName
                                 
                                 
                             };
                return result.ToList();

            }

        }

        public List<PersonRole> GetPersonRole(string username)
        {
            using (PersonManagementContext context = new PersonManagementContext())
            {
                var result = from p in context.Persons
                             join c in context.Role on p.RoleId equals c.RoleId
                             where p.Username == username
                             select new PersonRole
                             {
                                 PersonId = p.PersonId,
                                 RoleName = c.RoleName
                             };
                return result.ToList();

            }
        }
    }
}
