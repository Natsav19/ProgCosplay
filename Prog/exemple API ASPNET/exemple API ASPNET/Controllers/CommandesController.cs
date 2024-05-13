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

namespace ProjectCosplay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommandesController : ControllerBase
    {
        private readonly ProjectCosplayContext _context;

        public CommandesController(ProjectCosplayContext context)
        {
            _context = context;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommande()
        {
            if (_context.Commande == null)
            {
                return NotFound();
            }
            if (!IsAdmin())
            {
                return NotFound();
            }
            return await _context.Commande.ToListAsync();
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
            if (_context.Commande == null)
            {
                return NotFound();
            }
            var commande = await _context.Commande.FindAsync(id);

            if (commande == null)
            {
                return NotFound();
            }
            if (!IsAdmin())
            {
                return NotFound();
            }

            return commande;
        }

        // PUT: api/Commandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.CommandeID)
            {
                return BadRequest();
            }
            if (!IsAdmin())
            {
                return NotFound();
            }

            _context.Entry(commande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
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

        // POST: api/Commandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            if (_context.Commande == null)
            {
                return Problem("Entity set 'ProjectCosplayContext.Commande'  is null.");
            }
            if (!IsAdmin())
            {
                return NotFound();
            }
            _context.Commande.Add(commande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommande", new { id = commande.CommandeID }, commande);
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            if (_context.Commande == null)
            {
                return NotFound();
            }
            var commande = await _context.Commande.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            if (!IsAdmin())
            {
                return NotFound();
            }

            _context.Commande.Remove(commande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandeExists(int id)
        {
            return (_context.Commande?.Any(e => e.CommandeID == id)).GetValueOrDefault();
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
