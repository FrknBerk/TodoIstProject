using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Entities.Abstract;

namespace TodoIstProject.Entities.Concrete
{
    public class AspNetUser :IEntity
    {
        public string NameSurname { get; set; }
        //public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string NormalizedEmail { get; set; }
        //public char EmailConfirmed { get; set; }
        //public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        //public string ConcurrencyStamp { get; set; }
        //public char PhoneNumberConfirmed { get; set; }
        //public char TwoFactorEnabled { get; set; }
        //public DateTime  LockoutEnd{ get; set; }
        //public int AccessFailedCount{ get; set; }
    }
}
