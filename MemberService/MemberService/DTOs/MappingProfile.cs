using AutoMapper;
using MemberService.DTOs;
using MemberService.Models;

namespace MemberService.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<CreateMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>();
        }
    }
}
