using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.DataAccess.Abstract;
using TodoIstProject.DataAccess.EntityFramework.Concrete;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.DataAccess.Concrete
{
    public class EfRoleDal : EfEntityRepositoryBase<AspNetRoles,ApplicationDbContext>,IRoleDal
    {
    }
}
