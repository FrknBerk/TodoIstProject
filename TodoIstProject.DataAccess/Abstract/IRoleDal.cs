using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.DataAccess.EntityFramework.Abstract;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.DataAccess.Abstract
{
    public interface IRoleDal : IEntityRepository<AspNetRoles>
    {
    }
}
