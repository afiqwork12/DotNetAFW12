using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeServiceApp.Services
{
    public interface IRepo<K, T>
    {
        Task<T> AddAsync(T t);
        Task<T> Update(T t);
        Task<T> Delete(K k);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetT(K k);
        void GetToken(string token);
    }
}
