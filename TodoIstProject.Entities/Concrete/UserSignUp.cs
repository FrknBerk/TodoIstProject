using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Entities.Abstract;

namespace TodoIstProject.Entities.Concrete
{
    public class UserSignUp : IEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
