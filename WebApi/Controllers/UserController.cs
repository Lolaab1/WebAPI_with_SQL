using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> Users = new List<User>() {
                new User() { UserId = 10,UserName = "ola",UserLocation = "sana'a" },
                new User() { UserId = 20,UserName = "Alia",UserLocation = "sana'a" },
            };

       
        [HttpGet]
        [EnableQuery()]

        public List<User> GetAllAuthor()
        {

            return Users;
        }

        [HttpGet("{Id}")]
        public IActionResult GetUserByID(int Id)
        {
            var CurUser = Users.Where(x => x.UserId == Id).FirstOrDefault();

            if (CurUser == null)
                return NotFound("Invalid User");
            return Ok(CurUser);
        }

        [HttpPost]
        public IActionResult AddUser(User NewUser)
        {
            if (string.IsNullOrWhiteSpace(NewUser.UserName))
            {
                return BadRequest("Invalid Empty User Name");
            }

            var CurUser = Users.Where(x => x.UserId == NewUser.UserId).SingleOrDefault();

            if (CurUser != null)
                return Conflict("Duplicate in User Id");

            Users.Add(NewUser);
            //return Ok();
            return CreatedAtAction("GetAuthorByID", new { Id = NewUser.UserId }, NewUser);
        }

        [HttpPut]
        public IActionResult UpdateUser(User updateuser)
        {
            if (string.IsNullOrWhiteSpace(updateuser.UserName))
            {
                return BadRequest("Invalid Empty User Name");
            }

            var CurUser = Users.Where(x => x.UserId == updateuser.UserId).SingleOrDefault();

            if (CurUser == null)
            {
                return NotFound("Invalid User");
            }

            CurUser.UserName = updateuser.UserName;
            CurUser.UserLocation = updateuser.UserLocation;

            return NoContent();
        }

        [HttpDelete("{Id}")]

        public IActionResult DeleteUser(int Id)
        {
            var CurUser = Users.Where(x => x.UserId == Id).FirstOrDefault();

            if (CurUser == null)
                return NotFound("Invalid User");
            Users.Remove(CurUser);
            return Ok("Deleted succes");
        }

    }
}
