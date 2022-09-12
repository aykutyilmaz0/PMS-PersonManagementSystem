using FluentValidation;
using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation
{
    public class LoginValidation:AbstractValidator<Persons>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username can't be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty");

        }
    }
}
