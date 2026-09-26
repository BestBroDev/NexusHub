using NexusHub.Domain.Enums;

namespace NexusHub.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }

    public TransactionType TransactionType { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public bool IsArchived { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // конструктор
    public Category(string name, TransactionType transactionType)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty.", nameof(name));
        if (transactionType != TransactionType.Income && transactionType != TransactionType.Expense)
            throw new ArgumentException("Category is not available.", nameof(transactionType));

        Id = Guid.NewGuid();
        TransactionType = transactionType;
        Name = name;
        IsArchived = false;
        CreatedAt = DateTime.UtcNow;
    }

    // переименовывание
    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty.", nameof(name));
        
        Name = name;
    }

    // архивация
    public void Archive()
    {
        IsArchived = true;
    }
}