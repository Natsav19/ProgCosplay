using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCosplay.Data;
using exemple_API_ASPNET.Models;

namespace exemple_API_ASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeCosplaysController : ControllerBase
    {
        private readonly ProjectCosplayContext _context;

        public CommandeCosplaysController(ProjectCosplayContext context)
        {
            _context = context;
        }

        // GET: api/CommandeCosplays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandeCosplay>>> GetCommandeCosplay()
        {
          if (_context.CommandeCosplay == null)
          {
              return NotFound();
          }
            return await _context.CommandeCosplay.ToListAsync();
        }

        // GET: api/CommandeCosplays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommandeCosplay>> GetCommandeCosplay(int id)
        {
          if (_context.CommandeCosplay == null)
          {
              return NotFound();
          }
            var commandeCosplay = await _context.CommandeCosplay.FindAsync(id);

            if (commandeCosplay == null)
            {
                return NotFound();
            }

            return commandeCosplay;
        }

        // PUT: api/CommandeCosplays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommandeCosplay(int id, CommandeCosplay commandeCosplay)
        {
            if (id != commandeCosplay.CommandeCosplayID)
            {
                return BadRequest();
            }

            _context.Entry(commandeCosplay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeCosplayExists(id))
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

        // POST: api/CommandeCosplays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommandeCosplay>> PostCommandeCosplay(CommandeCosplay commandeCosplay)
        {
          if (_context.CommandeCosplay == null)
          {
              return Problem("Entity set 'ProjectCosplayContext.CommandeCosplay'  is null.");
          }
            _context.CommandeCosplay.Add(commandeCosplay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommandeCosplay", new { id = commandeCosplay.CommandeCosplayID }, commandeCosplay);
        }

        // DELETE: api/CommandeCosplays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommandeCosplay(int id)
        {
            if (_context.CommandeCosplay == null)
            {
                return NotFound();
            }
            var commandeCosplay = await _context.CommandeCosplay.FindAsync(id);
            if (commandeCosplay == null)
            {
                return NotFound();
            }

            _context.CommandeCosplay.Remove(commandeCosplay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandeCosplayExists(int id)
        {
            return (_context.CommandeCosplay?.Any(e => e.CommandeCosplayID == id)).GetValueOrDefault();
        }
    }
}
