using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Entities.Abstract;

namespace TodoIstProject.Entities.Concrete
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime RefreshDate { get; set; }
    }
}
