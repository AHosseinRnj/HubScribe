using FluentValidation;

namespace HubScribe.Application.Features.Commands.Articles.CreateArticle;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}