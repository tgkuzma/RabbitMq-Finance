using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data.Repositories
{
    public class RepositoryBase<T> where T : class
    {
        private readonly DataContext _context;
        private readonly IRepositoryEvents _repositoryEvents;

        public RepositoryBase(DataContext context, IRepositoryEvents repositoryEvents)
        {
            _context = context;
            _repositoryEvents = repositoryEvents;
        }

        public RepositoryBase()
        {
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            var itemsToSend = _context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged)
                .ToDictionary(e => e.State.ToString(), e => e.Entity);

            _context.SaveChanges();
            var changesSavedArgs = new ChangesSavedEventArgs
            {
                Entries = itemsToSend
            };
            _repositoryEvents.OnChangesSaved(changesSavedArgs);
        }
    }
}