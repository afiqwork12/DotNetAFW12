using SampleMCVTogetherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Services
{
    public class UserTempService : IRepo<string, User>
    {
        public User Add(User t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string k)
        {
            int number = new Random().Next(100, 200);
            if (number > 150)
            {
                return true;
            }
            return false;
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetT(string k)
        {
            throw new NotImplementedException();
        }

        public bool Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
