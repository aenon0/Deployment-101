// using System;
// using Application.Contracts.Persistence;
// using Application.DTOs;
// using Application.Features.Contest.Requests;
// using AutoMapper;
// using MediatR;
// namespace Application.Features.Contest.Handlers.Queries
// {
//     public class GetContestQuestionsRequestHandler : IRequestHandler<GetContestQuestionsRequest, List<QuestionDto>>
//     {
//         private readonly IQuestionContestRepository _questionContestRepository;
//         private readonly IMapper _mapper;

//         public GetContestQuestionsRequestHandler(IQuestionContestRepository questionContestRepository, IMapper mapper)
//         {
//             _mapper = mapper;
//             _questionContestRepository = questionContestRepository;
//         }

//         public async Task<List<QuestionDto>> Handle(GetContestQuestionsRequest request, CancellationToken cancellationToken)
//         {
//             var questions = await _questionContestRepository.GetQuestionsByContestId(request.ContestId);
//             return _mapper.Map<List<QuestionDto>>(questions);
//         }
//     }
// }

