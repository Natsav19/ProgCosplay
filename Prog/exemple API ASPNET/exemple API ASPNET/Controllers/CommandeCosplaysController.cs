using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCosplay.Authentification;
using ProjectCosplay.Data;
using ProjectCosplay.Models;

namespace exemple_API_ASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommandeCosplaysController : ControllerBase
    {
        private readonly ProjectCosplayContext _context;

        public CommandeCosplaysController(ProjectCosplayContext context)
        {
            _context = context;
        }

        // GET: api/CommandeCosplays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandeCosplays>>> GetCommandeCosplays()
        {
            if (_context.CommandeCosplays == null)
            {
                return NotFound();
            }
            return await _context.CommandeCosplays.ToListAsync();
        }

        // GET: api/CommandeCosplays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommandeCosplays>> GetCommandeCosplays(int id)
        {
            if (_context.CommandeCosplays == null)
            {
                return NotFound();
            }
            var commandeCosplays = await _context.CommandeCosplays.FindAsync(id);

            if (commandeCosplays == null)
            {
                return NotFound();
            }

            return commandeCosplays;
        }
        [HttpGet("{ClientID,Status}")]
        public async Task<ActionResult<IEnumerable<CommandeCosplays>>> GetCommandeCosplays(string ClientID,  string Status)
        {
            if (_context.CommandeCosplays == null)
            {
                return NotFound();
            }

            var commandes = await _context.CommandeCosplays
                .Where(c => c.ClientNom == ClientID && c.Status == Status)
                .ToListAsync();

            if (commandes == null || !commandes.Any())
            {
                return NotFound();
            }

            return commandes;
        }

        // PUT: api/CommandeCosplays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommandeCosplays(int id, CommandeCosplays commandeCosplays)
        {
            if (id != commandeCosplays.CommandeCosplaysID)
            {
                return BadRequest();
            }

            _context.Entry(commandeCosplays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeCosplaysExists(id))
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
        public async Task<ActionResult<CommandeCosplays>> PostCommandeCosplays(CommandeCosplays commandeCosplays)
        {
            if (_context.CommandeCosplays == null)
            {
                return Problem("Entity set 'ProjectCosplayContext.CommandeCosplays'  is null.");
            }
            _context.CommandeCosplays.Add(commandeCosplays);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommandeCosplays", new { id = commandeCosplays.CommandeCosplaysID }, commandeCosplays);
        }

        // DELETE: api/CommandeCosplays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommandeCosplays(int id)
        {
            if (_context.CommandeCosplays == null)
            {
                return NotFound();
            }
            var commandeCosplays = await _context.CommandeCosplays.FindAsync(id);
            if (commandeCosplays == null)
            {
                return NotFound();
            }

            _context.CommandeCosplays.Remove(commandeCosplays);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandeCosplaysExists(int id)
        {
            return (_context.CommandeCosplays?.Any(e => e.CommandeCosplaysID == id)).GetValueOrDefault();
        }

        private bool IsAdmin()
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type ==
            ClaimTypes.Role))
                return RolesUtilisateurs.Administrateur == currentUser.Claims.First(c =>
                c.Type == ClaimTypes.Role).Value;
            return false;
        }
    }
}
