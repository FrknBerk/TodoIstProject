using Project.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Business.Abstract;
using TodoIstProject.DataAccess.Abstract;
using TodoIstProject.DataAccess.Concrete;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(AspNetUser user)
        {
            _userDal.Add(user);
            return new SuccessResult("KULLANICI başarılı bir şekilde eklendi");
        }
    }
}
