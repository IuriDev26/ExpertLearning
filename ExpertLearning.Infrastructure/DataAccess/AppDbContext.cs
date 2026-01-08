using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.SharedContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExpertLearning.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Flashcard> Flashcards { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {

            if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
            {

                modelBuilder
                    .Entity(entityType.ClrType)
                    .HasKey(nameof(Entity.Id))
                    .HasName($"{entityType.ClrType.Name.ToLower()}_pkey");
                
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property(nameof(Entity.Id))
                    .HasColumnName("id")
                    .IsRequired();
                
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property(nameof(Entity.CreatedAt))
                    .HasColumnName("created_at")
                    .HasColumnType("timestamptz")
                    .IsRequired();
                
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property(nameof(Entity.UpdatedAt))
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamptz")
                    .IsRequired();
            }
        }
        
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        
        IEnumerable<EntityEntry<Entity>> entries = ChangeTracker
            .Entries<Entity>()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

        foreach (EntityEntry<Entity> entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                    entry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                    break;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}