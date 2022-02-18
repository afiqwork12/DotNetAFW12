using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayAPI.Services
{
    public interface IRepo<K, T>
    {
        Task<T> Add(T t);
        Task<T> Update(T t);
        Task<T> Delete(K k);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetT(K k);
    }
}
