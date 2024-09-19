using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repo
{
    public interface IRepo<T>
        where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, params string[] Includes);
        public Task<T> GetAsync(int id, params string[] Includes);
        public Task<bool> AddAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
    }
}
