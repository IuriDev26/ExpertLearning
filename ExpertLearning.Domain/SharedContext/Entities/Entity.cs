namespace ExpertLearning.Domain.SharedContext.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }

    protected Entity()
    {
        CreatedAt = DateTime.Now;
    }
}