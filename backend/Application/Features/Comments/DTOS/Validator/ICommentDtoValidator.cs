using FluentValidation;

namespace Application.Features.Comments.DTOS.Validator;

public class ICommentDtoValidator : AbstractValidator<ICommentDto>
{
    public ICommentDtoValidator()
    {
        RuleFor(p => p.Message)
        .NotEmpty().WithMessage("{PropertyName} can not be empty")
        .NotNull().WithMessage("{PropertyName} can not be null");
    }
}
