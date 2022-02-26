using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// allows us to save it to the database in asynchronous methods
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();

        /// <summary>
        /// allows us to save it to the database in synchronous methods
        /// </summary>
        /// <returns></returns>
        void Commit();
    }
}
