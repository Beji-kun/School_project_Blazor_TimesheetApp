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
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return NotFound();
        }
    }
}
