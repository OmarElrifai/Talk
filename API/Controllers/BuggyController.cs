using API.Data;
using API.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : APIController
    {
        private readonly userdata _data;
        public BuggyController(userdata data)
        {
            _data = data;
        }

        [Authorize]
        [HttpGet("Auth")]
        public ActionResult<string> Auth()
        {
            return "Secret Text";
        }
        
        [HttpGet("BadRequest")]
        public ActionResult<string> badRequest()
        {
            return BadRequest();
        }

        [HttpGet("NotFound")]
        public ActionResult<Appusers> Not_Found()
        {
            
            var thing = _data.users.Find(-1);
            if(thing==null) return NotFound();
            return Ok(thing);
        }

        [HttpGet("ServerError")]
        public ActionResult<string> ServerError()
        {
            
            var thing = _data.users.Find(-1);
            var newThing=thing.ToString();
            return newThing;
        }
        
    }
}