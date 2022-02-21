using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeAPIApplication.Services
{
    public interface IRepo<K, T>
    {
        void GetToken(string token);
        Task<T> Get(K key);
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T> Delete(K key);
        Task<IEnumerable<T>> GetAll();
    }
}
