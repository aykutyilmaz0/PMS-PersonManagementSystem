using FluentValidation;
using PersonManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation
{
    public class DepartmentValidation: AbstractValidator<Department>
    {
        public DepartmentValidation()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Department name can't be empty");
        }
    }
}
