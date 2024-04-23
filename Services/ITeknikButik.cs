namespace SUT23_TeknikButik.Services
{
    public interface ITeknikButik<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
        
    }
}
