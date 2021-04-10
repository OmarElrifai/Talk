using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class userscontroller : APIController
    {
        private readonly userdata _data;
        public userscontroller(userdata data)
        {
            _data = data;

        }
        
        [HttpGet]
         [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Appusers>>> gett()
        {
            return await _data.users.ToListAsync() ;
        }
        
        [Authorize]
        [HttpGet("{ID}")]

        public async Task<ActionResult<Appusers>> gett(int ID)
        {
            return await _data.users.FindAsync(ID) ;
        }

    }
}