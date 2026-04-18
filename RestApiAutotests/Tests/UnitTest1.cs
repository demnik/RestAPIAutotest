using AutotestObjects;

namespace RestApiAutotests;

public class Tests
{
    [Test]
    [Description("Получение всех книг доступных по /api/v1/Books")]
    public void GetBooks()
    {
        var books = Book.GetAllBooks();
        Assert.That(books, Is.Not.Empty);
    }
}
