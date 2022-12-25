using Project.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Business.Abstract;
using TodoIstProject.DataAccess.Abstract;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public IResult Add(AspNetRoles role)
        {
            _roleDal.Add(role);
            return new SuccessResult("Role başarılı bir şekilde eklendi");
        }
    }
}
