using FluentValidation;
using Twitter.Application.Commands.CreateComment;

namespace Twitter.Application.Validators
{
    public class CreateTweetCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateTweetCommentCommandValidator()
        {
            RuleFor(c => c.TweetComment)
                .NotEmpty().WithMessage("Comentário não pode estar vazio!")
                .NotNull().WithMessage("Comentário não pode estar vazio!")
                .MaximumLength(255).WithMessage("Tamanho máximo de comentário é de 255 caracteres");
        }
    }
}
