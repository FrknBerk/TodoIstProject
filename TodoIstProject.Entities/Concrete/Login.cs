using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Entities.Abstract;

namespace TodoIstProject.Entities.Concrete
{
    public class Login : IEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
