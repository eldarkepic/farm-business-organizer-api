using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class UserRepo : IUserRepo
    {
        public bool CompanyExists(int companyId)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(int companyId, User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers(int companyId)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int companyId, int userId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int companyId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
