using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Comments.CQRS.Queries;
using Application.Features.Comments.DTOS;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Comments.CQRS.Handlers;

public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, BaseResponse<CommentDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetCommentQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseResponse<CommentDto>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<CommentDto>();
        var comment = await _unitOfWork.CommentRepository.Get(request.Id);

        if (comment == null){
            throw new NotFoundException($"Comment with the {request.Id} is not found");
        }
        var commentDto = _mapper.Map<Comment,CommentDto>(comment);
        response.Message = "Comment delivered Successfully";
        response.Value = commentDto;
        return response;
    }
}

 