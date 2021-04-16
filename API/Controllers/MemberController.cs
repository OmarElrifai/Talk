using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MemberController:APIController
    {
        private readonly userdata _data;
        private readonly IMapper mapper;
        private readonly IUserRepository _rep;

        public MemberController(IMapper mapper,IUserRepository rep)
        {
            this.mapper = mapper;
            _rep = rep;
        }

         [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTOs>>> GetMembers()
        {
            var users= await _rep.GetMembers();
            return Ok(users);
        }

        [HttpGet("{Username}")]

        public async Task<ActionResult<MemberDTOs>> GetMembers(string Username)
        {
            var user= await _rep.GetMember(Username);
            return user;
        }
        
    }
}