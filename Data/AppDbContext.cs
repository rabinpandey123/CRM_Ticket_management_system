using CRM_Ticket_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM_Ticket_management_system.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
    }
}