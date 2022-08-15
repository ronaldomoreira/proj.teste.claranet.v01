using DomainApp.Interfaces.Business.Base;
using DomainApp.Interfaces.Repository.Base;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Base
{
    public class BusinessServiceBase<TEntity> : IBusinessServiceBase<TEntity> where TEntity : class
    {
        private readonly AppMainDbContext _context;
        private readonly IRepositoryBaseReadWrite<TEntity> _repository;

        public BusinessServiceBase(AppMainDbContext context, IRepositoryBaseReadWrite<TEntity> repository)
        {
            this._context = context;
            _repository = repository;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    if (_repository != null) { 
                        _repository.Dispose(); 
                    }
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.

                disposedValue = true;
            }

        }
        public virtual void Dispose()
        {
            Dispose(true);
        }
        #endregion

        public virtual async Task<TEntity?> GetById(long? id)
        {
            return await _repository.GetById(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<TEntity?> Add(TEntity item)
        {
            return await _repository.Add(item);
        }

        public virtual async Task AddRange(IEnumerable<TEntity> itens)
        {
            await _repository.AddRange(itens);
        }

        public virtual void Update(TEntity item)
        {
            _repository.Update(item);
        }

        public virtual async Task Remove(long? id)
        {
            await _repository.Remove(id);                
        }

        public virtual async Task Remove(TEntity item)
        {
            await _repository.Remove(item);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> itens)
        {
            _repository.RemoveRange(itens);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _repository.SaveChangesAsync();
        }
    }
}
