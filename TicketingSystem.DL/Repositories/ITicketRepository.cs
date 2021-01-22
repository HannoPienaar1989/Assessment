using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DL.Entities;
using Assessment.Shared.Models;

namespace Assessment.DL.Repositories
{
    public interface ITicketRepository
    {
        IEnumerable<GetInTouch> GetAllTickets();
        Ticket GetTicketById(int ticket);
        IEnumerable<Ticket> GetTicketByUserId(string userId);
        IEnumerable<Ticket> DeleteTicketById(string userId, int ticketId);
        GetInTouch AddNewTicket(GetInTouch ticket);
        Ticket UpdateTicket(Ticket ticket);
        void Commit();
    }
}
