using System.Collections.Generic;
using System.Linq;

public class Repository<T> where T : class
{
    private readonly UniversityContext _context;

    public Repository(UniversityContext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll() => _context.Set<T>().ToList();
    public void Add(T entity) { _context.Set<T>().Add(entity); _context.SaveChanges(); }
    public void Update(T entity) { _context.Set<T>().Update(entity); _context.SaveChanges(); }
    public void Delete(T entity) { _context.Set<T>().Remove(entity); _context.SaveChanges(); }
}
