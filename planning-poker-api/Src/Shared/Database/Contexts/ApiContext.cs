using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanningPokerApi.Src.Shared.Database.Entities;

namespace PlanningPokerApi.Src.Shared.Database.Contexts
{
  public class ApiContext : DbContext
  {
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<CardEntity> Cards { get; set; }

    public DbSet<UsersHistoryEntity> UsersHistories { get; set; }

    public DbSet<VoteEntity> Votes { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserEntity>()
          .HasIndex(b => b.Email)
          .IsUnique();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
      OnBeforeSaving();
      return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(
      bool acceptAllChangesOnSuccess,
      CancellationToken cancellationToken = default(CancellationToken))
    {
      OnBeforeSaving();
      return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                    cancellationToken));
    }

    private void OnBeforeSaving()
    {
      var entries = ChangeTracker.Entries();
      var utcNow = DateTime.UtcNow;

      foreach (var entry in entries)
      {
        // for entities that inherit from BaseEntity,
        // set UpdatedOn / CreatedOn appropriately
        if (entry.Entity is BaseEntity trackable)
        {
          switch (entry.State)
          {
            case EntityState.Modified:
              // set the updated date to "now"
              trackable.UpdatedAt = utcNow;

              // mark property as "don't touch"
              // we don't want to update on a Modify operation
              entry.Property("CreatedAt").IsModified = false;
              break;

            case EntityState.Added:
              // set both updated and created date to "now"
              trackable.CreatedAt = utcNow;
              trackable.UpdatedAt = utcNow;
              break;
          }
        }
      }
    }

  }
}
