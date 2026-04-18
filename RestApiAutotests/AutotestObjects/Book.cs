namespace AutotestObjects;

public class Book(Dictionary<string, object> data)
{
    private Dictionary<string, object> Data = data;

    /// <summary>
    /// Возвращает все книги
    /// </summary>
    /// <returns>Все книги</returns>
    public static List<Book> GetAllBooks()
    {
        var result = RestApiAutotests.Utils.Client.Get("/api/v1/Books");

        return [.. result.Select(d => new Book(d))];
    }
}
