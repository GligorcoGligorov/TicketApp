using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TicketRepository : ITicketRepository
    { 
        private DbSet<MovieTicket> _entities;
        private readonly ApplicationDbContext _context;
        
        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<MovieTicket>();
        }

        
        
        public MovieTicket Get(Guid? id)
        {
            var query = _entities.Include(e => e.Movie).Where(e => e.Id.Equals(id));
            return query.FirstOrDefault();
        }
        public IEnumerable<MovieTicket> GetAll()
        {
            var query = _entities.Include(e => e.Movie);
            return query.ToList();
        }
        
        

        
        public MovieTicket Update(MovieTicket entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException("entity");
            }
            _entities.Update(entity);
            _context.SaveChanges();

            return entity;
        }
        public MovieTicket Delete(MovieTicket entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();

            return entity;
        }
        
        public MovieTicket Insert(MovieTicket entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        
    }
}