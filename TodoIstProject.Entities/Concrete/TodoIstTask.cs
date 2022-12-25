using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoIstProject.Entities.Concrete
{
    public class TodoIstTask : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public int UserId { get; set; }

        public string CreateTaskId { get; set; }

        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
