using AutoMapper;
using BlogProgram.Common.DTO.Request;
using BlogProgram.Common.DTO.Response;
using BlogProgram.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProgram.Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorRequestDto, Author>();
            CreateMap<Author, AuthorResponseDto>();
        }
       
    }
}
