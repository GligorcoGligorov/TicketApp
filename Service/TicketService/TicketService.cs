using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Repository;

namespace Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        
        

        
        
        public MovieTicket UpdateExistingTicket(MovieTicket updatedTicket)
        {
            return _repository.Update(updatedTicket);
        }

        public MovieTicket CreateNewTicket(MovieTicket newEntity)
        {
            return _repository.Insert(newEntity);
        }

        public MovieTicket GetSpecificTicket(Guid? id)
        {
            return _repository.Get(id);
        }
        public List<MovieTicket> GetAllTicketAsList()
        {
            return _repository.GetAll().ToList();
        }
        

        

        public bool TicketExist(Guid? id)
        {
            return _repository.Get(id) != null;
        }
        public List<MovieTicket> GetAllTicketAsList(DateTime? date)
        {
            var ticketList = _repository.GetAll().Where(t => t.Date.Date == date?.Date).ToList();
            return ticketList;
        }
        public MovieTicket DeleteTicket(Guid? id)
        {
            var ticket = _repository.Get(id);
            if (ticket == null)
            {
                throw new ArgumentException("Ticket not found");
            }
            return _repository.Delete(ticket);
        }

        
    }
}