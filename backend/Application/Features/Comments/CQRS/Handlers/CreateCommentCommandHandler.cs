using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Comments.CQRS.Commands;
using Application.Features.Comments.DTOS.Validator;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Comments.CQRS.Handlers;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<int>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var response  = new BaseResponse<int>();
        var validator = new CreateCommentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CommentDto!);

        if (validationResult.IsValid){
            var comment = _mapper.Map<Comment>(request.CommentDto);
            var countOperations = await _unitOfWork.CommentRepository.Add(comment);

            if (countOperations == 0){
                throw new InternalServerErrorException("Internal server failed to add the given entity");
            }
            response.Message = "Comment created successfully";
            response.Value = comment.Id;

            return response;
        }
        else{
            throw new System.ComponentModel.DataAnnotations.ValidationException("Comment is not valid");
        }



    }
}

