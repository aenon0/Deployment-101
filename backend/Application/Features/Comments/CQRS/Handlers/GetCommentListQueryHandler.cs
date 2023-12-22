using Application.Contracts.Persistence;
using Application.Features.Comments.CQRS.Queries;
using Application.Features.Comments.DTOS;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Comments.CQRS.Handlers;

public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, BaseResponse<List<CommentDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetCommentListQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseResponse<List<CommentDto>>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<CommentDto>>();
        var comments = (List<Comment>) await _unitOfWork.CommentRepository.GetAll();
        var commentDtos = _mapper.Map<List<Comment>,List<CommentDto>>(comments);

        response.Value = commentDtos;
        response.Message = "Comments delivered Successfully";

        return response;

    }
}

