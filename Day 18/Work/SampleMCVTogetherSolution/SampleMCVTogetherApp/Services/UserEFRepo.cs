using SampleMCVTogetherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Services
{
    public class UserEFRepo : IRepo<string, User>//IAdding<string, User>
    {
        private readonly ShopContext _context;
        public UserEFRepo(ShopContext context)
        {
            _context = context;
        }
        public User Add(User t)
        {
            _context.Users.Add(t);
            if (SaveChanges())
            {
                return t;
            }
            return null;
        }

        public bool Delete(string k)
        {
            _context.Users.Remove(GetT(k));
            return SaveChanges();
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetT(string k)
        {
            return _context.Users.SingleOrDefault(c => c.Username == k);
        }

        public bool Update(User t)
        {
            _context.Users.Update(t);
            return SaveChanges();
        }
        private bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
