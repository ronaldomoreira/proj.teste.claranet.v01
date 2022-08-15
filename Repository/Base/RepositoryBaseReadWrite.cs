using DomainApp.Interfaces;
using DomainApp.Interfaces.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class RepositoryBaseReadWrite<TEntity> : IRepositoryBaseReadWrite<TEntity> where TEntity : class
    {
        private readonly AppMainDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBaseReadWrite(AppMainDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
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
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.

                disposedValue = true;
            }

        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        public async Task<TEntity?> GetById(long? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            List<TEntity> listEntity = new();

            try
            {
                listEntity = await _dbSet.ToListAsync();
            }
            catch (Exception)
            {
                //throw;
            }

            return listEntity;
        }

        public async Task<TEntity?> Add(TEntity item)
        {
            var x = await _dbSet.AddAsync(item);
            return x.Entity;
        }

        public async Task AddRange(IEnumerable<TEntity> itens)
        {
            await _dbSet.AddRangeAsync(itens);
        }

        public void Update(TEntity item)
        {
            if (item != null) 
            { 
                _dbSet.Update(item);
            }
        }

        public async Task Remove(long? id)
        {
            var item =  await _dbSet.FindAsync(id);

            if (item != null)
            {
                _dbSet.Remove(item);
            }
        }

        public async Task Remove(TEntity item)
        {
            if (item != null)
            {
                var itemTmp = await _dbSet.FindAsync(item);
                if (itemTmp != null)
                {
                    _dbSet.Remove(itemTmp);
                }
            }
        }

        public void RemoveRange(IEnumerable<TEntity> itens)
        {
            if (itens != null)
            {
                _dbSet.RemoveRange(itens);
            }

        }

        public async Task<int> SaveChangesAsync()
        {
            return  await _context.SaveChangesAsync();
        }
    }
}
