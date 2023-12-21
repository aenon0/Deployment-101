using System;
using System.Text.Json;
using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.DTOs;
using AutoMapper;
using Domain.Entites;

namespace Application.Usecases
{
	public class ContestUsecase
	{
		private readonly IContestRepository _contestRepository;
		private readonly IQuestionRepository _questionRepository;
		private readonly IQuestionContestRepository _questionContestRepository;
		private readonly IMapper _mapper;
		private readonly ICodeforcesService _codeforcesServices;

		public ContestUsecase(IMapper mapper,  IContestRepository contestRepository, IQuestionContestRepository questionContestRepository, IQuestionRepository questionRepository, ICodeforcesService codeforcesServices)
		{
			_questionRepository = questionRepository;
			_questionContestRepository = _questionContestRepository;
			_contestRepository = contestRepository;
			_codeforcesServices = codeforcesServices;
			_mapper = mapper;
		}

		public async Task ProcessContest( ContestDto contestDto)
		{
			int contestId = _contestRepository.Get(contestDto.URL).Id;
            var response = _codeforcesServices.GetContestProblems(contestId);
			if (!response.IsCompletedSuccessfully)
			{
				Console.Write("Not able to process.");
				return;
			}

			try
			{
				var stream = await response.Result.Content.ReadAsStreamAsync();
				var jsonDocument = await JsonDocument.ParseAsync(stream);
				var result = jsonDocument.RootElement.GetProperty("data");
				List<dynamic> questionsWithDetail = JsonSerializer.Deserialize<List<dynamic>>(result.GetRawText());
				//adding the contest
				await _contestRepository.Add(_mapper.Map<Contest>(contestDto));
               
               
                foreach (var questionWithDetail in questionsWithDetail)
				{
					var questionDto = new QuestionDto
					{
						URL = questionWithDetail.original_problem_url
					};
                    //adding the questions
                    await _questionRepository.Add(_mapper.Map<Question>(questionDto));

                    //adding the contest-question relationship
                    int questonId = await _questionRepository.Get(questionWithDetail.original_problem_url);
					var questionContestDto = new QuestionContestDto
					{
                        QuestionId = questonId,
						ContestId = contestId,
						Name = questionWithDetail.in_contest_name
                    };

					await _questionContestRepository.Add(_mapper.Map<QuestionContest>(questionContestDto));
				}
				

			}
			catch (JsonException ex)
			{
				Console.WriteLine($"Error parsing JSON: {ex.Message}");
			}

        }

	}
}

