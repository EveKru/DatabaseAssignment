using Infrastructure.Contexts;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

    public virtual TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;

    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        var entity = _context.Set<TEntity>().ToList();
        return entity;

    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression) 
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        return entity!;

    }

    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
        _context.SaveChanges();

        return entityToUpdate!;
    }

    public virtual void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entityToDelete = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Remove(entityToDelete!);
        _context.SaveChanges();
    }


}

