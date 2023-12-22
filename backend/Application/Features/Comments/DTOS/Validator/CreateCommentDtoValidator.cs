using FluentValidation;

namespace Application.Features.Comments.DTOS.Validator;

public class CreateCommentDtoValidator :  AbstractValidator<CreateCommentDto>
{
    public CreateCommentDtoValidator()
    {
        Include(new ICommentDtoValidator());
    }
}
