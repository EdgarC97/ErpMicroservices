using MemberService.DTOs;
using MemberService.Models;

namespace MemberService.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
        Task<MemberDto?> GetMemberByIdAsync(int id);
        Task CreateMemberAsync(CreateMemberDto dto);
        Task UpdateMemberAsync(int id, UpdateMemberDto dto);
        Task DeleteMemberAsync(int id);
    }
}
