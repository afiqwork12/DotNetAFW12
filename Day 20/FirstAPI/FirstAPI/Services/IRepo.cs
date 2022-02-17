using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public interface IRepo<K, T> 
    {
        T Add(T t);
        T Update(T t);
        T Delete(K k);
        IEnumerable<T> GetAll();
        T GetT(K k);
    }
}
