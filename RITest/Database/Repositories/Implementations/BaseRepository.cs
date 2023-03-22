using Microsoft.EntityFrameworkCore;
using RITest.Database.Repositories.Interfaces;
using RITest.Entities.abstracts;
using System.Reflection;

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

        public T Update<P>(P model) where P: BaseModel
        {
            T toUpdate = Context.Set<T>().FirstOrDefault(m => m.Id == model.Id);

            if (toUpdate == null)
                throw new Exception("Entry instance is Null");

            PropertyInfo[] modelFields = typeof(P).GetProperties();
            foreach (PropertyInfo prop in modelFields)
                if(prop.GetValue(model)!=null) typeof(T).GetProperty(prop.Name).SetValue(toUpdate, prop.GetValue(model));

            Context.Set<T>().Update(toUpdate);
            Context.SaveChanges();

            return Context.Set<T>().FirstOrDefault(m => m.Id == model.Id);
        }

        public T Get(int id)
        {
            return Context.Set<T>().FirstOrDefault(m => m.Id == id);
        }
    }
}
