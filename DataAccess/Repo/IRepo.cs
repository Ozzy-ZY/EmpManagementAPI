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
        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, params string[] Includes);
        public Task<T> Get(int id, params string[] Includes);
        public Task<bool> Add(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
    }
}
