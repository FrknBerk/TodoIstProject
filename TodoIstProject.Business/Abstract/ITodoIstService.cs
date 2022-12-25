using Project.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.Business.Abstract
{
    public interface ITodoIstService
    {
        IResult Add(TodoIstTask todoIstTask);
        IDataResult<List<TodoIstTask>> GetAll();
        List<TodoIstTask> GetById(int id);
        TodoIstTask GetByIdTodo(int id);
        bool Update(TodoIstTask todoIstTask);
    }
}
