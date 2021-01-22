using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Assessment.BL.Interfaces;
using Assessment.DL.Entities;
using Assessment.DL.Repositories;
using Assessment.Shared.Models;

namespace Assessment.BL.Implementations
{
    public class TicketService: ITicketService
    {
        private ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public IEnumerable<GetInTouchDTO> GetAllTickets()
        {
            var tickets = _ticketRepository.GetAllTickets();
            return _mapper.Map<List<GetInTouchDTO>>(tickets);
        }

        public IEnumerable<TicketDTO> GetTicketByUserId(string userId)
        {
            var tickets = _ticketRepository.GetTicketByUserId(userId);
            return _mapper.Map<List<TicketDTO>>(tickets);
        }

        public TicketDTO GetTicketById(int ticketId)
        {
            return _mapper.Map<TicketDTO>(_ticketRepository.GetTicketById(ticketId));
        }
        public GetInTouchDTO AddNewTicket(GetInTouchDTO ticket)
        {
            var obj = _mapper.Map<GetInTouch>(ticket);
            return _mapper.Map<GetInTouchDTO>(_ticketRepository.AddNewTicket(obj));
        }
        public TicketDTO UpdateTicket(int ticketId, TicketDTO ticket)
        {
            var t = _mapper.Map<Ticket>(ticket);
            return _mapper.Map<TicketDTO>(_ticketRepository.UpdateTicket(t));
        }
        public IEnumerable<TicketDTO> DeleteTicketById(string userId, int ticketId)
        {
            var tickets = _ticketRepository.DeleteTicketById(userId, ticketId);
            return _mapper.Map<List<TicketDTO>>(tickets);
        }
    }
}
