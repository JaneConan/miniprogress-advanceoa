#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetapp;
using RestSharp;

namespace aspnetapp.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApletUsersController : ControllerBase
    {
        private readonly CounterContext _context;

        public ApletUsersController(CounterContext context)
        {
            _context = context;
        }

        // GET: api/ApletUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApletUser>>> GetApletUsers()
        {
            return await _context.ApletUsers.ToListAsync();
        }

        // GET: api/ApletUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApletUser>> GetApletUser(int id)
        {
            var apletUser = await _context.ApletUsers.FindAsync(id);

            if (apletUser == null)
            {
                return NotFound();
            }

            return apletUser;
        }

        // PUT: api/ApletUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApletUser(int id, ApletUser apletUser)
        {
            if (id != apletUser.id)
            {
                return BadRequest();
            }

            _context.Entry(apletUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApletUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApletUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApletUser>> PostApletUser(ApletUser apletUser)
        {
            apletUser.createdAt = DateTime.Now;
            _context.ApletUsers.Add(apletUser);
            await _context.SaveChangesAsync();

            //post请求
            var SMS_API = Environment.GetEnvironmentVariable("SMS_API");
            var client = new RestClient(SMS_API);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { number = apletUser.Phone, message = "尊敬的" + apletUser.UserName + "，您好。您的需求我们已收到，随后我们会有工作人员和您联系。感谢您的支持！" });
            // 执行请求
            var response = await client.PostAsync(request);
            var content = response.Content; // raw content as string

            return CreatedAtAction("GetApletUser", new { id = apletUser.id, result = content }, apletUser);
        }

        // DELETE: api/ApletUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApletUser(int id)
        {
            var apletUser = await _context.ApletUsers.FindAsync(id);
            if (apletUser == null)
            {
                return NotFound();
            }

            _context.ApletUsers.Remove(apletUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApletUserExists(int id)
        {
            return _context.ApletUsers.Any(e => e.id == id);
        }
    }
}
