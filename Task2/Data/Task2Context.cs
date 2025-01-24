using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.Data
{
    public class Task2Context : DbContext
    {
        public Task2Context (DbContextOptions<Task2Context> options)
            : base(options)
        {
        }

        public DbSet<Task2.Models.Movie> Movie { get; set; } = default!;
    }
}
