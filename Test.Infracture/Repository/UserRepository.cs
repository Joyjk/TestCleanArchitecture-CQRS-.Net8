using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.IRepository;
using Test.Domain.Model;
using Test.Infracture.DBContext;

namespace Test.Infracture.Repository
{
    class UserRepository : IUserRepository
    {
        private readonly DatabaseDbContext _dBContext;
        public UserRepository(DatabaseDbContext databaseDb)
        {
            _dBContext = databaseDb;
        }
        public User GetUserbyName(string Name)
        {
            var data = _dBContext.Users.Where(d => d.UserName == Name).FirstOrDefault();
            return data??new User();
        }

        public bool SaveUser(User user)
        {
            user.CreateBy = "Admin";
            //user.CreateDate = DateTime.Now;
            _dBContext.Users.Add(user);
            if(_dBContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
