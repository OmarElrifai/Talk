using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly userdata _data;

        private readonly IMapper _mapper;

        public UserRepository(userdata data, IMapper mapper)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<IEnumerable<MemberDTOs>> GetMembers()
        {
            return await _data.users
            .ProjectTo<MemberDTOs>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<MemberDTOs> GetMember(string Username)
        {
            return await _data.users
            .Where(x=>x.Username==Username)
            .ProjectTo<MemberDTOs>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<Appusers> GetUserByIdAsync(int id)
        {
            return await _data.users.FindAsync(id);
        }

        public async Task<Appusers> GetUserByUsernameAsync(string Username)
        {
            return await _data.users.Include(p => p.photos)
            .SingleOrDefaultAsync(x => x.Username == Username);

        }

        public async Task<IEnumerable<Appusers>> GetUsersAsync()
        {
            return await _data.users.Include(p => p.photos).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _data.SaveChangesAsync() > 0;
        }

        public void Update(Appusers users)
        {
            _data.Entry(users).State = EntityState.Modified;
        }
    }
}