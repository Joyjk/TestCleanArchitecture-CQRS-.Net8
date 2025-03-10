using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Model;

namespace Test.Domain.IRepository
{
    public interface IUserRepository
    {
        public User GetUserbyName(string Name);
        public bool SaveUser(User user);
    }
}
