using PersonManagementSystem.Entities;
using PersonManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Abstract
{
    public interface IPersonService
    {
        List<Persons> GetAllPerson();
        void AddPerson(Persons persons);
        void UpdatePerson(Persons persons);
        void DeletePerson(Persons persons);
        Persons GetPerson(string username,string password);
        Persons GetPersonDetail(int PersonId);
        List<PersonRole> GetPersonRole(string username);
        List<PersonelDetails> GetPersonelDetail();
    }
}
