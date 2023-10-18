using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceManagement.Models;

namespace StudentAttendanceManagement.Data
{
    public class StudentAttendanceDetailsContext : DbContext
    {
        public StudentAttendanceDetailsContext (DbContextOptions<StudentAttendanceDetailsContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAttendanceManagement.Models.StudentAttendanceDetails> StudentAttendanceDetails { get; set; } = default!;
    }
}
