using System;
using Application.DTOs;
using Application.DTOs.ContestDtos;
using Application.Features.Comments.DTOS;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contest, ContestDto>().ReverseMap();
            CreateMap<Generation, GenerationDto>().ReverseMap();
            CreateMap<GenGroup, GenGroupDto>().ReverseMap();
            CreateMap<HeadGenGroup, HeadGenGroupDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionContest, QuestionContestDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserContestHistory, UserContestHistoryDto>().ReverseMap();

            // start
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, ICommentDto>().ReverseMap();
            // end








        }


    }
}

