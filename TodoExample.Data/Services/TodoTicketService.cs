using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoExample.Data.Models;

namespace TodoExample.Data.Services
{
    public interface ITodoTicketService
    {
        List<TodoTicket> GetAllTickets();
        TodoTicket? GetTicketById(string id);
        List<TodoTicket> GetTicketByStatusId(string statusId);
        Task<TodoTicket> InsertTicket(TodoTicket newTicket);
        Task<TodoTicket> UpdateTicket(TodoTicket updateTicket);
        Task<bool> DeleteTicket(TodoTicket ToDeleteTicket);
    }

    public class TodoTicketService : ITodoTicketService
    {
        private TodoDbContext dbContext;

        public TodoTicketService(TodoDbContext context)
        {
            dbContext = context;
        }

        public List<TodoTicket> GetAllTickets()
        {

            var ticketList = dbContext.TodoTicket
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
            return ticketList;
        }

        public TodoTicket? GetTicketById(string id)
        {
            return dbContext.TodoTicket.FirstOrDefault(x => x.TodoTicketId == id);
        }

        public List<TodoTicket> GetTicketByStatusId(string statusId)
        {
            return dbContext.TodoTicket
                .Where(x => x.TodoStatusId == statusId)
                .ToList();
        }

        public async Task<TodoTicket> InsertTicket(TodoTicket newTicket)
        {
            await dbContext.TodoTicket.AddAsync(newTicket);
            await dbContext.SaveChangesAsync();

            return newTicket;
        }

        public async Task<TodoTicket> UpdateTicket(TodoTicket updateTicket)
        {
            TodoTicket? existTicket = GetTicketById(updateTicket.TodoTicketId);

            if(existTicket == null)
            {
                await InsertTicket(updateTicket);
                return updateTicket;
            }

            existTicket = updateTicket;
            dbContext.Update(existTicket);
            await dbContext.SaveChangesAsync();

            return existTicket;


        }
        
        public async Task<bool> DeleteTicket(TodoTicket ToDeleteTicket)
        {
            dbContext.TodoTicket.Remove(ToDeleteTicket);

            await dbContext.SaveChangesAsync();

            return true;
        }

    }
}