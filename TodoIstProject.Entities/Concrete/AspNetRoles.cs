using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Entities.Abstract;

namespace TodoIstProject.Entities.Concrete
{
    public class AspNetRoles : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}
