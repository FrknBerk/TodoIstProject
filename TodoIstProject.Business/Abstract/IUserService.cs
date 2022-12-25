using Project.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.Business.Abstract
{
    public interface IUserService
    {
        IResult Add(AspNetUser user);
    }
}
