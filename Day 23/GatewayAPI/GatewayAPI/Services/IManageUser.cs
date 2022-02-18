using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayAPI.Services
{
    public interface IManageUser<T>
    {
        Task<T> Add(T user);
        Task<T> Login(T user);
    }
}
