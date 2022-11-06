using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoExample.Data.Models;

namespace TodoExample.Data.Services
{
    public interface IVTodoTicketService
    {
        List<VTodoTicket> GetAll();
        VTodoTicket? GetById(string id);

        List<VTodoTicket> GetByStatusId(string statusid);
    }

    public class VTodoTicketService : IVTodoTicketService
    {

        private TodoDbContext dbContext;

        public VTodoTicketService(TodoDbContext context)
        {
            dbContext = context;
        }
        public List<VTodoTicket> GetAll()
        {
            return dbContext.VTodoTicket.ToList();
        }

        public VTodoTicket? GetById(string id)
        {
            return dbContext.VTodoTicket.FirstOrDefault(x => x.TodoTicketId == id);
        }

        public List<VTodoTicket> GetByStatusId(string statusid)
        {
            return dbContext.VTodoTicket.Where(x => x.TodoStatusId == statusid).ToList();
        }
    }
}
