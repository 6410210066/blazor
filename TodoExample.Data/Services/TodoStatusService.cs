using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoExample.Data.Models;

namespace TodoExample.Data.Services
{
    public interface ITodoStatusService
    {
        List<TodoStatus> GetAllStatus();

        TodoStatus? GetStatusById(string id);

    }

    public class TodoStatusService : ITodoStatusService
    {
        private TodoDbContext dbContext;

        public TodoStatusService(TodoDbContext context)
        {
            dbContext = context;
        }

        public List<TodoStatus> GetAllStatus()
        {
            return dbContext.TodoStatus.ToList();
        }

        public TodoStatus? GetStatusById(string id)
        {
            return dbContext.TodoStatus.FirstOrDefault(x => x.TodoStatusId == id);
        }
    }

    
}
