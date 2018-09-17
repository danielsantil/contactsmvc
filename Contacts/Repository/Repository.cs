using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contacts.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ContactsDbContext _context;

        public Repository(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(expression);
            Detach(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Detach(T entity)
        {
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
