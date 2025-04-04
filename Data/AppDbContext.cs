using Microsoft.EntityFrameworkCore;
using SysGestFullstack.Models;


namespace SysGestFullstack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<UserLog> UserLogs { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }

    }
}

