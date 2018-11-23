using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sow.Components.Databases.Repositories.Interfaces
{
    public interface IReadRepositoryBase<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> GetById(string id);
    }
}
