using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Components.Databases.Repositories.Interfaces
{
    public interface IWriteRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity e);

        Task<bool> Update(TEntity e);
    }
}
