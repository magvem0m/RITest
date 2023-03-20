namespace RITest.Controllers.Interfaces
{
    public interface ICRUD<T, ICreate, IUpdate> where T : class where ICreate : class where IUpdate : class
    {
        public Task<T> Create(ICreate dto);
        public Task<T> Update(IUpdate dto);
        public Task<int> Delete(int Id);
        public Task<T> Get(int Id);
        public Task<List<T>> GetAll();
    }
}
