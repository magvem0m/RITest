using Microsoft.EntityFrameworkCore;
using RITest.Entities.abstracts;

namespace RITest.Database.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public DbSet<T> GetContext();
        public List<T> GetAll();
        public T Get(int id);
        public T Create(T model);
        public T Update<P>(P model) where P: BaseModel;
        public int Delete(int id);
    }
}
