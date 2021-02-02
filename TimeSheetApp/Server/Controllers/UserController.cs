using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Server.DAL;
using TimeSheetApp.Shared.Models;

namespace TimeSheetApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllUsers")]
        public List<User> GettAllUsers()
        {
            return _context.Users.ToList();
        }
        [HttpGet("Get/{id}")]
        public async Task<User> GetUserByID(int? id)
        {
            User user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }
            return user;
        }
        [HttpPost("Post")]
        public void Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<string> DeleteUser(int? id)
        {
            User user_del = await GetUserByID(id);
            if (user_del == null)
            {
                return null;
            }
            else
            {
                _context.Users.Remove(user_del);
                await _context.SaveChangesAsync();
                return "User deleted successfully";
            }

        }
    }
}
