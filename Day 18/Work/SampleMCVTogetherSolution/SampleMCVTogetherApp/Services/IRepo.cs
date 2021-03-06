using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Services
{
    public interface IRepo<K, T> : IAdding<K, T>
    {
        bool Update(T t);
        bool Delete(K k);
        ICollection<T> GetAll();
        T GetT(K k);
    }
}
