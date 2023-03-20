using Microsoft.EntityFrameworkCore;
using RITest.Database;
using RITest.Database.Repositories.Interfaces;
using RITest.Entities;
using RITest.Entities.abstracts;

namespace RITest.Database.Repositories.Implementations
{
    public class BaseRepository<T>: IBaseRepository<T> where T: BaseModel
    {
        private DataContext Context { get; set; }
        public BaseRepository(DataContext context)
        {
            Context = context;
        }

        public DbSet<T> GetContext()
        {
            return Context.Set<T>();
        }

        public T Create(T model)
        {
            Context.Set<T>().Add(model);
            Context.SaveChanges();
            
            return Context.Set<T>().FirstOrDefault(m => m.Id == model.Id); ;
        }

        public int Delete(int id)
        {
            var toDelete = Context.Set<T>().FirstOrDefault(m => m.Id == id);
            Context.Set<T>().Remove(toDelete);
            return Context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Update(T model)
        {
            var toUpdate = Context.Set<T>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return Context.Set<T>().FirstOrDefault(m => m.Id == model.Id);
        }

        public T Get(int id)
        {
            return Context.Set<T>().FirstOrDefault(m => m.Id == id);
        }
    }
}
