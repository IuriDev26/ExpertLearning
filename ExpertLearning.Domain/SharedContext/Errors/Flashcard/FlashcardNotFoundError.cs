namespace ExpertLearning.Domain.SharedContext.Errors.Flashcard;

public record FlashcardNotFoundError() : Error("Flashcard.NotFound", "Flashcard não encontrado.");