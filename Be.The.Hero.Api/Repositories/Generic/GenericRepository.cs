
using Be.The.Hero.Api.Config;
using Be.The.Hero.Api.Interfaces.Repositories;
using Be.The.Hero.Api.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Repositories.Generic
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {

        private readonly BeTheHeroSQLiteContext _context;

        private DbSet<TEntity> _db;

        public GenericRepository(BeTheHeroSQLiteContext context)
        {
            _context = context;
            _db = _context.Set<TEntity>();
        }

        public async Task<TEntity> InsertAsync(TEntity item)
        {
            try
            {
                _db.Add(item);
                await _context.SaveChangesAsync();                
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<TEntity> SelectByIdAsync(TKey id)
        {
            try
            {
                Expression<Func<TEntity, bool>> predicate = t => t.Id.Equals(id);
                return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IEnumerable<TEntity>> SelectAllAsync()
        {
            try
            {
                return await _db.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> SelectFilterAsync(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                var query =
                 await _db
                    .Where(where)
                    .OrderByDescending(ent => ent.Id)
                    .AsNoTracking()
                    .ToListAsync()
                    .ConfigureAwait(false);

                return query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                var currentEntity = await SelectByIdAsync(entity.Id).ConfigureAwait(false);
                _context.Entry(currentEntity).CurrentValues.SetValues(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            try
            {
                var entity = await SelectByIdAsync(id).ConfigureAwait(false);
                if (entity != null)
                {
                    await Task.FromResult(_db.Remove(entity));
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ExistsAsync(TKey id)
        {
            var result = await SelectByIdAsync(id).ConfigureAwait(false);

            if(result != null)
            {
                return true;
            }

            return false;
        }
    }
}
