using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //localhost:5001/api/members
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
           var members = await context.Users.ToListAsync();
           return members; 
        }

        [HttpGet("{id}")] //localhost:5001/api/members/bob-id

        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var memmber = await context.Users.FindAsync(id);
            if (memmber == null) return NotFound();
            return memmber;
        }
          
    }
}