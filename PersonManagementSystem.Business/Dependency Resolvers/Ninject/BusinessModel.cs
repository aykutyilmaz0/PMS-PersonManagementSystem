using Ninject.Modules;
using PersonManagementSystem.Business.Abstract;
using PersonManagementSystem.Business.Concrete.Managers;
using PersonManagementSystem.DataAccess.Abstract;
using PersonManagementSystem.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementSystem.Business.Dependency_Resolvers.Ninject
{
    public class BusinessModel : NinjectModule
    {
        public override void Load()
        {
            //person model
            Bind<IPersonService>().To<PersonManager>().InSingletonScope();
            Bind<IPersonDal>().To<EfPersonDal>().InSingletonScope();

            //role mode
            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

            //Department mode
            Bind<IDepartmentService>().To<DepartmentManager>().InSingletonScope();
            Bind<IDepartmentDal>().To<EfDepartmentDal>().InSingletonScope();
        }
    }
}
