
using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.SharedContext.UseCases.Abstractions;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.LearningContext.ValueObjects;

namespace ExpertLearning.Application.LearningContext.UseCases.CreateSubject;

public sealed class Command(string name) : Request<Subject>
{
    public string Name { get; } = name;

    public override bool Validate() => !string.IsNullOrWhiteSpace(Name);
}