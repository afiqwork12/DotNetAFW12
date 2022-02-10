using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.Services
{
    public interface IRepo<K, T>
    {
        bool Add(T t);
        bool Update(T t);
        bool Delete(K k);
        ICollection<T> GetAll();
        T GetT(K k);
    }
}
