using PersonManagementSystem.Business.Abstract;
using PersonManagementSystem.Business.Aspect.PostSharp.ValidationAspect;
using PersonManagementSystem.Business.Dependency_Resolvers.Validation;
using PersonManagementSystem.DataAccess.Abstract;
using PersonManagementSystem.Entities;
using PersonManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Concrete.Managers
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }
        public void AddPerson(Persons persons)
        {
            _personDal.AddOperation(persons);
        }

        public Persons GetPerson(string username, string password)
        {
            var person = _personDal.GetPerson(x => x.Username == username && x.Password == password);
            return person;


        }

        public List<Persons> GetAllPerson()
        {
            return _personDal.ListOperation();
        }

        public List<PersonRole> GetPersonRole(string username)
        {
            return _personDal.GetPersonRole(username);
        }
        
        public void UpdatePerson(Persons persons)
        {
            _personDal.UpdateOperation(persons);
        }

        public List<PersonelDetails> GetPersonelDetail()
        {
            return _personDal.GetPersonDetails();
        }

        public void DeletePerson(Persons persons)
        {
            _personDal.DeleteOperation(persons);
        }

        public Persons GetPersonDetail(int PersonId)
        {
            return _personDal.GetPerson(x=>x.PersonId==PersonId);
        }
    }
}
