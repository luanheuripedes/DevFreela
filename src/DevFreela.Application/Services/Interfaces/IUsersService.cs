using DevFreela.Application.InputModels.UserInputModels;
using DevFreela.Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUsersService
    {
        int Create(CreateUserInputModel inputModel);
        UserViewModel GetById(int id);
       // UsersDetailsViewModel Login(int id);
    }
}
