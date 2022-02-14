using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Services
{
    public interface IAdding<K, T>
    {
        T Add(T t);
    }
}
