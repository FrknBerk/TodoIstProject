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
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;   
        }

        public IResult UserLogin(Login login)
        {
            var result = _loginDal.GetById(x => x.NameSurname == login.UserName && x.Password == login.Password);
            return new SuccessResult("Giriş Başarılı");
        }
    }
}
