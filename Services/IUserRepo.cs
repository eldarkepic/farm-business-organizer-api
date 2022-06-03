using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers(int companyId);
        User GetUserById(int companyId, int userId);
        void CreateUser(int companyId, User user);
        void UpdateUser(int companyId, User user);
        void DeleteUser(User user);
        bool CompanyExists(int companyId);
        bool SaveChanges();
    }
}
