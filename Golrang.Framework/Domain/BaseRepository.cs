using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golrang.Framework.Domain
{
    public interface BaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        TEntity Get(int id);
        List<TEntity> Get();
        void Remove(int postId);
        void Update(TEntity entity);
    }
}