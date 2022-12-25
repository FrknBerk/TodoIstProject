using Project.Core.Utilities.Business;
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
    public class TodoIstManager : ITodoIstService
    {
        ITodoIstDal _todoIstDal;
        public TodoIstManager(ITodoIstDal todoIstDal)
        {
            _todoIstDal = todoIstDal;
        }

        public IResult Add(TodoIstTask todoIstTask)
        {
            _todoIstDal.Add(todoIstTask);
            return new SuccessResult("Eklendi");
        }

        public IDataResult<List<TodoIstTask>> GetAll()
        {
            return new SuccessDataResult<List<TodoIstTask>>(_todoIstDal.GetAll());
        }

        public List<TodoIstTask> GetById(int id)
        {
            var result = _todoIstDal.GetAll().Where(x=> x.UserId == id).ToList();
            return result;
        }

        public TodoIstTask GetByIdTodo(int id)
        {
            var result = _todoIstDal.GetById(x => x.Id == id);
            return result;
        }

        public bool Update(TodoIstTask todoIstTask)
        {
            try
            {
                _todoIstDal.Update(todoIstTask);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
