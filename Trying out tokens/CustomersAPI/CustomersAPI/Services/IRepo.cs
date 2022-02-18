using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersAPI.Services
{
    public interface IRepo<K, T>
    {
        T Add(T item);
        T Update(T item);
        T Delete(K key);
        IEnumerable<T> GetAll();
        T GetT(K key);
    }
}
