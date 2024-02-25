using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM_project.Models;

namespace CRM_project.Data
{
    public class CRM_projectContext : DbContext
    {
        public CRM_projectContext (DbContextOptions<CRM_projectContext> options)
            : base(options)
        {
        }

        public DbSet<CRM_project.Models.Student> Student { get; set; } = default!;
    }
}
