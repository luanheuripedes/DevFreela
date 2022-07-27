using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task CreateUserAsync(User user);

        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
