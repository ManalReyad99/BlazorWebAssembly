using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day3.WASM.Services
{
    public interface IService<T>
    {//CRUD
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T item);
        Task Update(int id,T item);
        Task Delete(int id);
    }
}
