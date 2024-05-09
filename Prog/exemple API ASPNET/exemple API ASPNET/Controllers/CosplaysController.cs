using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;
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
    public class CosplaysController : ControllerBase
    {
        private readonly ProjectCosplayContext _context;

        public CosplaysController(ProjectCosplayContext context)
        {
            _context = context;
        }

        // GET: api/Cosplays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cosplay>>> GetCosplay()
        {
          if (_context.Cosplay == null)
          {
              return NotFound();
          }
          return await _context.Cosplay.ToListAsync();
        }
        // GET: api/Cosplays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cosplay>> GetCosplay(int id)
        {
          if (_context.Cosplay == null)
          {
              return NotFound();
          }
            var cosplay = await _context.Cosplay.FindAsync(id);

            if (cosplay == null)
            {
                return NotFound();
            }
            if (!IsAdmin() && cosplay.ProprietaireId != GetUserName())
            {
                return NotFound();
            }

            return cosplay;
        }
        [Authorize]
        // PUT: api/Cosplays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCosplay(int id, 
            [Bind(nameof(Cosplay.CosplayID), nameof(Cosplay.Titre))]Cosplay cosplay)
        {
            if (id != cosplay.CosplayID)
            {
                return BadRequest();
            }
            var cosplayBD = await _context.Cosplay.FindAsync(id);
            if(cosplayBD == null && (cosplayBD.ProprietaireId == GetUserName() || IsAdmin()))
            {
                cosplayBD.Titre = cosplay.Titre;
                _context.Entry(cosplay).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CosplayExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return NoContent();
        }

        // POST: api/Cosplays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cosplay>> PostCosplay([Bind(nameof(Cosplay.Titre))] Cosplay cosplay)
        {
          if (_context.Cosplay == null)
          {
              return Problem("Entity set 'exemple_API_ASPNETContext.Cosplay'  is null.");
          }
            cosplay.ProprietaireId = GetUserName();
            _context.Cosplay.Add(cosplay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCosplay", new { id = cosplay.CosplayID }, cosplay);
        }

        // DELETE: api/Cosplays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCosplay(int id)
        {
            if (_context.Cosplay == null)
            {
                return NotFound();
            }
            var cosplay = await _context.Cosplay.FindAsync(id);
            if (cosplay == null || (cosplay.ProprietaireId != GetUserName() && !IsAdmin()))
            {
                return NotFound();
            }

            _context.Cosplay.Remove(cosplay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CosplayExists(int id)
        {
            return (_context.Cosplay?.Any(e => e.CosplayID == id)).GetValueOrDefault();
        }

        private string? GetUserName() 
        { 
            var currentUser = HttpContext.User; 
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name)) 
                return currentUser.Claims.FirstOrDefault(c => c.Type ==
                ClaimTypes.Name)?.Value;
            return null;
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
