using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    [Produces("application/json")]
    [Route("api/SupportTicket")]
    public class SupportTicketController : Controller
    {
        private readonly SupportTicketContext _context;

        public SupportTicketController(SupportTicketContext context)
        {
            _context = context;
        }

        // GET: api/SupportTicket
        [HttpGet]
        public IEnumerable<SupportTicket> GetSupportTicket()
        {
            return _context.SupportTicket;
        }

        // GET: api/SupportTicket/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupportTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supportTicket = await _context.SupportTicket.SingleOrDefaultAsync(m => m.Id == id);

            if (supportTicket == null)
            {
                return NotFound();
            }

            return Ok(supportTicket);
        }

        // PUT: api/SupportTicket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportTicket([FromRoute] int id, [FromBody] SupportTicket supportTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supportTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(supportTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportTicketExists(id))
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

        // POST: api/SupportTicket
        [HttpPost]
        public async Task<IActionResult> PostSupportTicket([FromBody] SupportTicket supportTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SupportTicket.Add(supportTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupportTicket", new { id = supportTicket.Id }, supportTicket);
        }

        // DELETE: api/SupportTicket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supportTicket = await _context.SupportTicket.SingleOrDefaultAsync(m => m.Id == id);
            if (supportTicket == null)
            {
                return NotFound();
            }

            _context.SupportTicket.Remove(supportTicket);
            await _context.SaveChangesAsync();

            return Ok(supportTicket);
        }

        private bool SupportTicketExists(int id)
        {
            return _context.SupportTicket.Any(e => e.Id == id);
        }
    }
}