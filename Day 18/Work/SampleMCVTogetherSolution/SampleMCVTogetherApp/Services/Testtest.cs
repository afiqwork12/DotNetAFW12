using SampleMCVTogetherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Services
{
    public class Testtest : IRepo<int, Customer>
    {
        public Customer Add(Customer t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int k)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetT(int k)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
