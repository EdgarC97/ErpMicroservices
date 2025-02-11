using AutoMapper;
using MemberService.DTOs;
using MemberService.Models;
using MemberService.Repositories;

namespace MemberService.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            var members = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }

        public async Task<MemberDto?> GetMemberByIdAsync(int id)
        {
            var member = await _repository.GetByIdAsync(id);
            return member == null ? null : _mapper.Map<MemberDto>(member);
        }

        public async Task CreateMemberAsync(CreateMemberDto dto)
        {
            var member = _mapper.Map<Member>(dto);
            await _repository.AddAsync(member);
        }

        public async Task UpdateMemberAsync(int id, UpdateMemberDto dto)
        {
            var existingMember = await _repository.GetByIdAsync(id);
            if (existingMember == null)
                throw new Exception("Member not found");

            _mapper.Map(dto, existingMember);
            await _repository.UpdateAsync(existingMember);
        }

        public async Task DeleteMemberAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
