using DevFreela.Application.ViewModels.UserViewModels;
using DevFreela.Core.IRepositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //Buscar no banco de dados um user que tenha um e-mail e minha senha em formato hash
            var user = await _repository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            //se nao existir, erro no login
            if(user == null)
            {
                return null;
            }

            //se existir,gero o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email,user.Role);
            var loginUserViewModel = new LoginUserViewModel(user.Email, token);


            return loginUserViewModel;
        
        }
    }
}
