using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Comments.DTOS.Validator;

public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCommentDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        Include(new ICommentDtoValidator());

        RuleFor(p => p.Id)
        .MustAsync(async (id,token) => {
            return await _unitOfWork.CommentRepository.Exists(id);
        });
    }
}

