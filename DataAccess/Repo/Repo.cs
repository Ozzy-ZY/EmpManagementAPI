using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repo
{
    public class Repo<T> : IRepo<T>
        where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repo(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var temp = await _dbSet.FindAsync(id);
            if(temp != null)
            {
                _dbSet.Remove(temp);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<T> GetAsync(int id, params string[] Includes)
        {
            var temp = await _dbSet.FindAsync(id);
            if (temp != null)
                return temp;
            else
                return null!;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, params string[] Includes)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query.Where(filter);
            }
            foreach(var inc in Includes)
            {
                query.Include(inc);
            }
            return await query.ToListAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
        }

        }

        //public async Task<bool> Add(Employee entity)
        //{
        //    await _context.AddAsync(entity);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    var temp = await _context.Employees.FindAsync(id);
        //    if ( temp != null)
        //    {
        //        _context.Employees.Remove(temp);
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<Employee> Get(int id, params string[] Includes)
        //{
        //    if (Includes != null)
        //    {
        //        foreach(var inc in Includes)
        //        {
        //            _context.Employees.Include(inc);
        //        }
        //    }
        //    var temp = await _context.Employees.FindAsync(id);
        //    if (temp != null)
        //        return temp;
        //    else
        //        return null;
        //}

        //public async Task<IEnumerable<T>> GetAll(Expression<Func<Employee, bool>>? filter, params string[] Includes)
        //{
        //    IQueryable<Employee> query = _context.Employees;
        //    if(filter != null)
        //    {
        //        query.Where(filter);
        //    }

        //    foreach(var inc in Includes)
        //    {
        //        query.Include(inc);
        //    }
        //    return await query.ToListAsync();
        //}

        //public async Task<bool> Update(Employee entity)
        //{
        //    _context.Employees.Attach(entity);
        //    _context.Entry(entity).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return true;

        //}
    }
