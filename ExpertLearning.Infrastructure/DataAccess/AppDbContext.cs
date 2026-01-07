using ExpertLearning.Domain.LearningContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertLearning.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Flashcard> Flashcards { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
}