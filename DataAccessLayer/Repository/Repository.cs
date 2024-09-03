using Amazon.Data;
using DataAccessLayer.IterfacesRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private TheContext _context;
        private DbSet<T> dbSet;
        private readonly ILogger _logger;
        public Repository(TheContext context, ILogger logger)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
            _logger = logger;
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Error adding entity");
                return false;
            }

        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                var theOne = await dbSet.FindAsync(entity);
                if (theOne != null) 
                {
                    dbSet.Remove(theOne);
                    return true ;
                }
                else
                {
                    _logger.LogWarning("Entity} not found for deletion", entity);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting entity");
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            try
            {
                var item = await dbSet.FindAsync(id);
                if(item == null)
                {
                    _logger.LogWarning("Entity with id {Id} was not found.", id);
                }
                return item;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error getting entity with id {Id}", id);
                return null;
            }
            
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
