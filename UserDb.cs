using Microsoft.EntityFrameworkCore;

public class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> opt) : base(opt) { }
    public DbSet<User> Users => Set<User>();
}