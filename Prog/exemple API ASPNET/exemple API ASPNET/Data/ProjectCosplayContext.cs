using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectCosplay.Models;

namespace ProjectCosplay.Data
{
    public class ProjectCosplayContext : IdentityDbContext<IdentityUser>
    {
        public ProjectCosplayContext (DbContextOptions<ProjectCosplayContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectCosplay.Models.Cosplay> Cosplay { get; set; } = default!;

        public DbSet<ProjectCosplay.Models.CommandeCosplays>? CommandeCosplays { get; set; }

        public DbSet<ProjectCosplay.Models.Commandes>? Commandes { get; set; }
    }
}
