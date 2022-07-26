using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("E-mail não valido!");

            RuleFor(p => p.Password).Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um numero, uma letra maiuscula e um caractere especial");

            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("O nome é obrigatorio");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

            return regex.IsMatch(password);
        }
    }
}
