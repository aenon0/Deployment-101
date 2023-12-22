using FluentValidation;

namespace Application.Features.Comments.DTOS.Validator;

public class CommentDtoValidator : AbstractValidator<CommentDto>
{
    public CommentDtoValidator()
    {
        Include(new ICommentDtoValidator());
    }
}

