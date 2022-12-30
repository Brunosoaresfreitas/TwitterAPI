using FluentValidation;
using Twitter.Application.Commands.CreateTweet;

namespace Twitter.Application.Validators
{
    public class CreateTweetCommandValidator : AbstractValidator<CreateTweetCommand>
    {
        public CreateTweetCommandValidator()
        {
            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("Descrição não pode estar vazia")
                .NotNull().WithMessage("Descrição não pode estar vazia")
                .MaximumLength(600).WithMessage("Tamanho máximo de descrição é de 600 caracteres");
        }
    }
}
