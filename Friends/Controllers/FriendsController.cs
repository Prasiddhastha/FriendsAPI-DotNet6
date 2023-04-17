using Friends.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Friends.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public FriendsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("Get")]
        public async Task<ActionResult<List<Friends>>> Get()
        {
            return Ok(await _dataContext.Friend.ToListAsync());
        }
        [HttpGet("Get {id}")]
        public async Task<ActionResult<List<Friends>>> Get(int id)
        {
            var sathi = await _dataContext.Friend.FindAsync(id);
            if(sathi == null)
            {
                return BadRequest("Friend Not Found");
            }
            return Ok(sathi);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<List<Friends>>> Add(Friends sathi)
        {
            _dataContext.Friend.Add(sathi);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Friend.ToListAsync());
        }

        [HttpPut("Update")]
        public async Task<ActionResult<List<Friends>>> Update(Friends request)
        {
            var dbsathi = await _dataContext.Friend.FindAsync(request.Id);
            if(dbsathi == null)
            return BadRequest("Friend Not Found");
            dbsathi.Name = request.Name;
            dbsathi.age = request.age;
            dbsathi.Role = request.Role;
            dbsathi.Salary = request.Salary;
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Friend.ToListAsync());

        }
        [HttpDelete("Delete {id}")]
        public async Task<ActionResult<List<Friends>>> Delete(int id)
        {
            var dbsathi = await _dataContext.Friend.FindAsync(id);
            if (dbsathi == null)
                return BadRequest("Friend Not Found");
            _dataContext.Friend.Remove(dbsathi);
           await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Friend.ToListAsync());
        }
    }
}
