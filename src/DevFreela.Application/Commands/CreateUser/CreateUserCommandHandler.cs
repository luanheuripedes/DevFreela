using DevFreela.Core.Entities;
using DevFreela.Core.IRepositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {

        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.Name, request.Email, request.BirthDate, passwordHash, request.Role);
            await _repository.CreateUserAsync(user);

            return user.Id;
        }
    }
}
