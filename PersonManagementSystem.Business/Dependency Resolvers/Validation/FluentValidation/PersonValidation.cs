using FluentValidation;
using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Dependency_Resolvers.Validation
{
    public class PersonValidation:AbstractValidator<Persons>
    {
        public PersonValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username can't be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Department can't be empty");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname can't be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname can't be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can't be empty");
        }
    }
}
