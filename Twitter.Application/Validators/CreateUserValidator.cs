using FluentValidation;
using System.Text.RegularExpressions;
using Twitter.Application.Commands.UsersCommands.CreateUser;

namespace Twitter.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Nome não pode estar vazio!")
                .NotNull().WithMessage("Nome não pode estar vazio!")
                .MinimumLength(3).WithMessage("Nome deve ter pelo menos 2 caracteres!")
                .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caracteres!");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Nome não pode estar vazio!")
                .NotNull().WithMessage("Nome não pode estar vazio!")
                .EmailAddress().WithMessage("O Email informado não é válido!");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Senha não pode estar vazia!")
                .NotNull().WithMessage("Senha não pode estar vazia!")
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, sendo pelo menos um número, uma letra maiúscula, uma minúscula e um caracter especial!");

            RuleFor(u => u.BirthDate)
                .NotEmpty().WithMessage("Senha não pode estar vazia!")
                .NotNull().WithMessage("Senha não pode estar vazia!")
                .Must(ValidBirthDate).WithMessage("O usuário deve ter no mínimo 6 anos de idade!");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }

        public bool ValidBirthDate(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-6);
        }
    }
}
