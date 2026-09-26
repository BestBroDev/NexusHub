namespace NexusHub.Domain.Entities;

public class Account
{
    // get - значение можно прочитать
    // private set - изменить значение может только сам класс
    public Guid Id { get; private set; } // уник. идентификатор (550e8400-e29b-41d4-a716-446655440000)

    public string Name { get; private set; } = string.Empty;

    public string Currency { get; private set; } = "RUB";

    public long InitialBalanceMinor { get; private set; }

    public bool IsArchived { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // конструктор
    public Account(
        string name,
        string currency,
        long initialBalanceMinor)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Account name cannot be empty.", nameof(name));
        
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency cannot be empty.", nameof(name));

        if (initialBalanceMinor < 0)
            throw new ArgumentOutOfRangeException(nameof(initialBalanceMinor), "Initial balance cannot be negative.");

        Id = Guid.NewGuid();
        Name = name;
        Currency = currency;
        InitialBalanceMinor = initialBalanceMinor;
        IsArchived = false;
        CreatedAt = DateTime.UtcNow;
    }

    // переименовывание
    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Account name cannot be empty.", nameof(name));
        
        Name = name;
    }

    // архивация
    public void Archive()
    {
        IsArchived = true;
    }
}