using Microsoft.EntityFrameworkCore;
using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using System.Linq.Expressions;

namespace ShippingSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task<IEnumerable<T>> GetAll(string? includePropertis)
        {
            IQueryable<T> query = dbSet;
            if (includePropertis != null)
            {
                foreach (var prop in includePropertis.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, string? includePropertis = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (includePropertis != null)
            {
                foreach (var prop in includePropertis.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includePropertis)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (includePropertis != null)
            {
                foreach (var prop in includePropertis.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetFirstOrDefault()
        {
            return await dbSet.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
