using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DL.Entities;
using Assessment.Shared.Models;

namespace Assessment.DL.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DBContext _dbContext;
        public TicketRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GetInTouch> GetAllTickets()
        {
            var tickets = _dbContext.GetInTouch;
            return tickets;
        }
        public IEnumerable<Ticket> GetTicketByUserId(string userId)
        {
            var tickets = _dbContext.Tickets.Where(t => t.CreatedByUserId == userId);
            foreach (var t in tickets)
            {
                t.IssueType = GetIssueType(t.IssueTypeId);
                t.IssueSeverity = GetIssueSeverity(t.IssueSeverityId);
                t.ResolutionStatus = GetResolutionStatus(t.ResolutionStatusId);
            }
            return tickets;
        }
        public IssueType GetIssueType(int id)
        {
            return _dbContext.IssueTypes.FirstOrDefault(i => i.IssueTypeId == id);
        }
        public IssueSeverity GetIssueSeverity(int id)
        {

            return _dbContext.IssueSeverity.FirstOrDefault(i => i.IssueSeverityId == id);
        }
        public ResolutionStatus GetResolutionStatus(int id)
        {

            return _dbContext.ResolutionStatus.FirstOrDefault(i => i.ResolutionStatusId == id);
        }
        public ResolutionSteps GetResolutionSteps(int ticketId)
        {
            return _dbContext.ResolutionSteps.FirstOrDefault(i => i.TicketId == ticketId);
        }

        public Ticket GetTicketById(int ticketId)
        {
            var t = _dbContext.Tickets.FirstOrDefault(u => u.TicketId == ticketId);
            if (t != null)
            {
                t.IssueType = GetIssueType(t.IssueTypeId);
                t.IssueSeverity = GetIssueSeverity(t.IssueSeverityId);
                t.ResolutionStatus = GetResolutionStatus(t.ResolutionStatusId);
                t.ResolutionSteps = GetResolutionSteps(t.TicketId);
            }
            return _dbContext.Tickets.FirstOrDefault(u => u.TicketId == ticketId);
        }
        public GetInTouch AddNewTicket(GetInTouch ticket)
        {

            _dbContext.GetInTouch.Add(ticket);
            _dbContext.SaveChanges();
            return ticket;
        }
        public Ticket UpdateTicket(Ticket ticket)
        {
            var update = _dbContext.Tickets.FirstOrDefault(u => u.TicketId == ticket.TicketId);
            if (update != null)
            {
                var steps = _dbContext.ResolutionSteps.FirstOrDefault(u => u.TicketId == ticket.TicketId);             
                
                if (steps != null)
                {
                    steps.Description = ticket.ResolutionSteps.Description;
                }
                else
                {
                    ticket.ResolutionSteps.TicketId = ticket.TicketId;
                    ticket.ResolutionSteps.ResolutionStatusId = ticket.ResolutionStatusId;
                    if (ticket.ResolutionSteps != null) _dbContext.ResolutionSteps.Add(ticket.ResolutionSteps);
                   
                }
                update = ticket;
                update.Comments = ticket.Comments;
                update.UpdatedAt = DateTime.Now;
                _dbContext.SaveChanges();
            }
            return update;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public IEnumerable<Ticket> DeleteTicketById(string userId, int ticketId)
        {
            var ticket = _dbContext.Tickets.FirstOrDefault(u => u.TicketId == ticketId);

            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();

            var tickets = _dbContext.Tickets.Where(t => t.CreatedByUserId == userId);
            foreach (var t in tickets)
            {
                t.IssueType = GetIssueType(t.IssueTypeId);
                t.IssueSeverity = GetIssueSeverity(t.IssueSeverityId);
                t.ResolutionStatus = GetResolutionStatus(t.ResolutionStatusId);
            }
            return tickets;
        }
    }
}
