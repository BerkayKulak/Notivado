﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate); 
        Task AddAsync(T entity);
        void Remove(T entity);
        T Update(T entity);
    }
}
