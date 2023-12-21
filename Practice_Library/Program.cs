using Practice_Library.Models;

class Program
{
    public static void Main()
    {
        /*Kitabxana sistemi ilə işləmək üçün əvvəlcə Library obyekti yaradın,
         * sonra lazım olan Book obyektlərini əlavə edin. 
         * Sifariş yaratmaq üçün Order obyekti yaradaraq lazımi kitabları əlavə edin və ümumi qiyməti hesablayın.*/

        Library library = new();
        string[] bookNames =
    {
            "Crime and Punishment", "The Brothers Karamazov", "The Idiot", "Notes from Underground",
            "War and Peace", "Anna Karenina", "The Gambler", "The Master and Margarita",
            "The Great Gatsby", "To Kill a Mockingbird", "1984", "The Catcher in the Rye",
            "Pride and Prejudice", "Jane Eyre", "Wuthering Heights", "One Hundred Years of Solitude",
            "The Lord of the Rings", "The Hobbit", "Harry Potter and the Sorcerer's Stone"
        };
        string[] authorNames =
        {
            "Fyodor Dostoevsky", "Leo Tolstoy", "Fyodor Dostoevsky", "Fyodor Dostoevsky",
            "Leo Tolstoy", "Leo Tolstoy", "Fyodor Dostoevsky", "Mikhail Bulgakov",
            "F. Scott Fitzgerald", "Harper Lee", "George Orwell", "J.D. Salinger",
            "Jane Austen", "Charlotte Brontë", "Emily Brontë", "Gabriel García Márquez",
            "J.R.R. Tolkien", "J.R.R. Tolkien", "J.K. Rowling"
        };


        Random rnd = new();
        for (int i = 0; i < 19; i++)
        {
            Book book = new()
            {
                Id = i + 1,
                Name = bookNames[i],
                AuthorName = authorNames[i],
                PageCount = rnd.Next(100, 500),
                Price = rnd.Next(5, 20)
            };
            book.GenerateCode();
            library.AddBook(book);
        }

         library.DisplayBooks(5);

        Order order = new()
        {
            Id = 1,
            Books = library.FindAllBooks(x => x.Id < 4),
            Date = DateTime.Now
        };

        order.ProcessSale();
    }
}