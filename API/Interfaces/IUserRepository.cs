using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(Appusers users);
        
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Appusers>> GetUsersAsync();
        Task<Appusers> GetUserByIdAsync(int id);
        Task<Appusers> GetUserByUsernameAsync(string Username); 

        Task<MemberDTOs> GetMember(string Username);
        Task<IEnumerable<MemberDTOs>> GetMembers();
        
    }
}