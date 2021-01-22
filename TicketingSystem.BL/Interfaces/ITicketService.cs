using System;
using System.Collections.Generic;
using System.Text;
using Assessment.Shared.Models;

namespace Assessment.BL.Interfaces
{
    public interface ITicketService
    {
        TicketDTO GetTicketById(int ticketId);
        IEnumerable<GetInTouchDTO> GetAllTickets();
        IEnumerable<TicketDTO> GetTicketByUserId(string userId);
        GetInTouchDTO AddNewTicket(GetInTouchDTO ticket);
        TicketDTO UpdateTicket(int ticketId, TicketDTO ticket);
        IEnumerable<TicketDTO> DeleteTicketById(string userId, int ticketId);
    }
}
