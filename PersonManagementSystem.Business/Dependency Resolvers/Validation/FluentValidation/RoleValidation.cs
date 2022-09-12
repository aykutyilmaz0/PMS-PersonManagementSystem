using FluentValidation;
using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation
{
    public class RoleValidation: AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Username can't be empty");
            
        }
    }
}
