using DevFreela.Application.InputModels.UserInputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.UserViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly DevFreelaDbContext _context;

        public UsersService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public UserViewModel GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.Name, user.Email);
        }
    }
}
