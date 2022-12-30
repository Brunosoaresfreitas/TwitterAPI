using FluentValidation;
using Twitter.Application.Commands.UpdateTweet;

namespace Twitter.Application.Validators
{
    public class UpdateTweetCommandValidator : AbstractValidator<UpdateTweetCommand>
    {
        public UpdateTweetCommandValidator()
        {
            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("Descrição não pode estar vazia")
                .NotNull().WithMessage("Descrição não pode estar vazia")
                .MaximumLength(600).WithMessage("Tamanho máximo de descrição é de 600 caracteres");
        }
    }
}
