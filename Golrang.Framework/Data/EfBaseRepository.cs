using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golrang.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Golrang.Framework.Data
{
    public class EfBaseRepository<TEntity> : BaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DbContext _dbContext;
        public EfBaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Add(entity);
            if (_dbContext.Entry(entity).Properties.Any(x => x.Metadata.FieldInfo.Name == "InsertDate"))
                _dbContext.Entry(entity).Property("InsertDate").CurrentValue = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            if (_dbContext.Entry(entity).Properties.Any(x => x.Metadata.FieldInfo.Name == "UpdateDate"))
                _dbContext.Entry(entity).Property("UpdateDate").CurrentValue = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public virtual TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(c => c.Id == id);
        }

        public List<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Remove(int postId)
        {
            var post = new TEntity
            {
                Id = postId
            };
            _dbContext.Set<TEntity>().Remove(post);
            _dbContext.SaveChanges();
        }
    }
}