using NexusHub.Domain.Entities;

namespace NexusHub.Domain.Tests.Entities;

public class AccountTests
{
    [Fact]
    public void CreateAccount_WithValidData_CreatesAccount()
    {
        var account = new Account(
            "Сбер",
            "RUB",
            10000
        );

        Assert.NotEqual(Guid.Empty, account.Id);
        Assert.Equal("Сбер", account.Name);
        Assert.Equal("RUB", account.Currency);
        Assert.Equal(10000, account.InitialBalanceMinor);
        Assert.False(account.IsArchived);
    }
    [Fact]
    public void CreateAccount_WithEmptyName_ThrowsException()
    {   
        
        Assert.Throws<ArgumentException>(() =>
        {
            new Account(
                "",
                "RUB",
                10000
            );
        });
    }
    [Fact]
    public void CreateAccount_WithEmptyCurrency_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Account("Сбер", "", 10000);
        });
    }
    [Fact]
    public void CreateAccount_WithNegativeBalance_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Account("Сбер", "RUB", -10000);
        });
    }
    [Fact]
    public void Rename_WithValidName_ChangesAccountName()
    {
        var account = new Account("Сбер", "RUB", 10000);

        account.Rename("Т-Банк");

        Assert.Equal("Т-Банк", account.Name);
    }
    [Fact]
    public void Rename_WithEmptyName_ThrowsException()
    {
        var account = new Account("Сбер", "RUB", 10000);

        Assert.Throws<ArgumentException>(() =>
        {
            account.Rename("");
        });
    }
    [Fact]
    public void Archive_ChangesAccountToArchive()
    {
        var account = new Account("Сбер", "RUB", 10000);

        account.Archive();

        Assert.True(account.IsArchived);
    }
}