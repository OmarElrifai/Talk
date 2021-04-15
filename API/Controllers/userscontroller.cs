using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class userscontroller : APIController
    {
        private readonly IUserRepository _rep;
        private readonly IMapper _mapper;

        public userscontroller(IUserRepository rep, IMapper mapper)
        {
            _mapper = mapper;
            _rep = rep;


        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<MemberDTOs>>> gett()
        {
            var users = await _rep.GetUsersAsync();
           var UsersToReturn = _mapper.Map<IEnumerable<MemberDTOs>>(users);
            return Ok(UsersToReturn);
        }




        [HttpGet("{Username}")]

        public async Task<ActionResult<MemberDTOs>> getbyusername(string Username)
        {
            var user =  await _rep.GetUserByUsernameAsync(Username);
            var UserToReturn = _mapper.Map<MemberDTOs>(user);
            return UserToReturn ;
        }

    }
}