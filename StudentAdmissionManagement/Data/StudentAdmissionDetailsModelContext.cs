using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAdmissionManagement.Models;

namespace StudentAdmissionManagement.Data
{
    public class StudentAdmissionDetailsModelContext : DbContext
    {
        public StudentAdmissionDetailsModelContext (DbContextOptions<StudentAdmissionDetailsModelContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAdmissionManagement.Models.StudentAdmissionDetailsModel> StudentAdmissionDetailsModel { get; set; } = default!;
    }
}
