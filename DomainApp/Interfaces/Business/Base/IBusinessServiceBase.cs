using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.Interfaces.Business.Base
{
    public interface IBusinessServiceBase<TEntity>: IDisposable where TEntity : class
    {
        Task<TEntity?> GetById(long? id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> Add(TEntity item);
        Task AddRange(IEnumerable<TEntity> itens);
        void Update(TEntity item);
        Task Remove(long? id);
        Task Remove(TEntity item);
        void RemoveRange(IEnumerable<TEntity> itens);

        Task<int> SaveChangesAsync();
    }
}
