using NexusHub.Domain.Entities;
using NexusHub.Domain.Enums;

namespace NexusHub.Domain.Tests.Entities;

public class CategoryTests
{
    [Fact]
    public void CreateCategory_WithValidData_CreatesCategory()
    {
        var category = new Category("Еда", TransactionType.Expense);

        Assert.NotEqual(Guid.Empty, category.Id);
        Assert.Equal("Еда", category.Name);
        Assert.Equal(TransactionType.Expense, category.TransactionType);
        Assert.False(category.IsArchived);
    }
    [Fact]
    public void CreateCategory_WithEmptyName_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Category("", TransactionType.Expense);
        });
    }
    [Fact]
    public void CreateCategory_WithSpaceName_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Category("  ", TransactionType.Expense);
        });
    }
    [Fact]
    public void CreateCategory_WithInvalidType_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Category("Еда", (TransactionType)123);
        });
    }
    [Fact]
    public void Rename_WithValidName_ChangesCategoryName()
    {
        var category = new Category("Еда", TransactionType.Expense);

        category.Rename("Транспорт");

        Assert.Equal("Транспорт", category.Name);
    }
    [Fact]
    public void Rename_WithEmptyName_ThrowsException()
    {
        var category = new Category("Еда", TransactionType.Income);

        Assert.Throws<ArgumentException>(() =>
        {
            category.Rename("");
        });

        Assert.Equal("Еда", category.Name);
    }
    [Fact]
    public void Archive_ChangesAccountToArchive()
    {
        var category = new Category("Еда", TransactionType.Income);

        category.Archive();

        Assert.True(category.IsArchived);
    }
}