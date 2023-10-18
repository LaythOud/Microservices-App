using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegisterSubject.Models;

namespace RegisterSubject.Data
{
    public class SubjectContext : DbContext
    {
        public SubjectContext (DbContextOptions<SubjectContext> options)
            : base(options)
        {
        }

        public DbSet<RegisterSubject.Models.Subject> Subject { get; set; } = default!;
    }
}
