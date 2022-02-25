using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        // asenkronlarda 
        Task CommitAsync();
        // senkronlarda
        void Commit();
    }
}
