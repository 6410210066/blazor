using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoExample.Data.Models;

namespace TodoExample.Data.Services
{
    public interface ITodoCategoryService
    {
        List<TodoCategory> GetAll();
        TodoCategory? GetById(string id);
    }

    public class TodoCategoryService : ITodoCategoryService
    {
        private TodoDbContext dbContext;

        public TodoCategoryService(TodoDbContext context)
        {
            dbContext = context;
        }

        public List<TodoCategory> GetAll()
        {
            return dbContext.TodoCategory.ToList();
        }

        public TodoCategory? GetById(string id)
        {
            return dbContext.TodoCategory.FirstOrDefault(x => x.CategoryId == id);
        }
    }
}