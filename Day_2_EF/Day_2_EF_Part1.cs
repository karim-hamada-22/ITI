using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class Repository<T> where T : class
{
    private readonly UniversityContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(UniversityContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll() => _dbSet.ToList();
    public void Add(T entity) { _dbSet.Add(entity); _context.SaveChanges(); }
    public void Update(T entity) { _dbSet.Update(entity); _context.SaveChanges(); }
    public void Delete(T entity) { _dbSet.Remove(entity); _context.SaveChanges(); }
}
