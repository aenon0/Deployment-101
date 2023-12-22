using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Comments.CQRS.Commands;
using Application.Features.Comments.DTOS.Validator;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CQRS.Handlers;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, BaseResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<Unit>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<Unit>();
        var validator = new UpdateCommentDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CommentDto!);

        if (validationResult.IsValid){
            var comment = await _unitOfWork.CommentRepository.Get(request.CommentDto!.Id);
            comment =  _mapper.Map(request.CommentDto,comment);

            var countOperations = await _unitOfWork.CommentRepository.Update(comment!);

            if (countOperations == 0){
                throw new InternalServerErrorException("Unable to update the comment due to server error");
            }
            response.Message = "Comment successfully updated";
            response.Value = new Unit();
            
            return response;
        }
        else{
            throw new ValidationException("Comment is invalid");
        }
    }
}
