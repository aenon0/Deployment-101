using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Comments.CQRS.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CQRS.Handlers;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, BaseResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCommentCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper; 
    }
    public async Task<BaseResponse<Unit>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<Unit>();
        var category = await _unitOfWork.CommentRepository.Get(request.Id);

        if(category == null){
            throw new NotFoundException($"category with {request.Id} not found");
        }
        var operations = await _unitOfWork.CommentRepository.Delete(category);
        
        if (operations == 0){
            throw new InternalServerErrorException("Server failed to remove the category");
        }

        response.Message = "Category deleted successfully";
        response.Value = new Unit();

        return response;

    }
}

