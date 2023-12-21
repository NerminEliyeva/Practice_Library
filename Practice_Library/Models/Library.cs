namespace Practice_Library.Models
{
    /// <summary>
    /// Bu sinif kitabxananın əsas funksiyalarını idarə edir.
    /// </summary>
    public class Library
    {
        /// <summary>
        /// Book obyektlərinin siyahısı
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
        /// <summary>
        /// Kitabxanaya yeni kitab əlavə edir.
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            Books?.Add(book);
        }
        /// <summary>
        /// Verilən şərtlərə uyğun kitabı qaytarır.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Book GetBook(Predicate<Book> condition)
        {
            return Books.Find(condition);
        }
        /// <summary>
        /// Verilən şərtlərə uyğun bütün kitabları qaytarır.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<Book> FindAllBooks(Predicate<Book> condition)
        {
            return Books.FindAll(condition);
        }
        /// <summary>
        /// Verilən şərtlərə uyğun kitabları silir və silinən kitabların sayını qaytarır.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int RemoveAllBooks(Predicate<Book> condition)
        {
            List<Book> booksToRemove = Books.FindAll(condition);
            Books.RemoveAll(condition);
            return booksToRemove.Count;
        }
        /// <summary>
        /// Kitablari verilmis sehifeye uygun ekrana cixarmaq
        /// </summary>
        public bool DisplayBooks(int pageNumber)
        {
            int booksCount = Books.Count;
            int booksCountInPage = 4;

            //sehife nomresinin mumkun en boyuk qiymetini tapiriq
            int maxPageNumber;
            if (booksCount % booksCountInPage == 0) maxPageNumber = booksCount / booksCountInPage;
            else maxPageNumber = booksCount / booksCountInPage + 1;

            //duzgun daxil edilmeyen sehife nomresi ucun yoxlama tetbiq edirik
            if (pageNumber > maxPageNumber || pageNumber <= 0)
            {
                Console.WriteLine($"Sehife nomresi yoxdur.Maximum sehife nomresi: {maxPageNumber}");
                return false;
            }

            //sehife nomresine uygun olacaq ekrana cixacaq ilk ve son kitabin indexini tapiriq
            int firstBookIndex = (pageNumber - 1) * booksCountInPage;
            int lastBookIndex;
            bool conditionForLastIndex = pageNumber != maxPageNumber;
            if (conditionForLastIndex) lastBookIndex = (firstBookIndex - 1) + booksCountInPage;
            else lastBookIndex = firstBookIndex - 1 + booksCount % booksCountInPage;

            for (int i = firstBookIndex; i <= lastBookIndex; i++)
            {
                Console.WriteLine($"Id: {Books[i].Id}");
                Console.WriteLine($"Name: {Books[i].Name}");
                Console.WriteLine($"Author: {Books[i].AuthorName}");
                Console.WriteLine($"Page Count: {Books[i].PageCount}");
                Console.WriteLine($"Price: {Books[i].Price.ToString()} AZN");
                Console.WriteLine();
            }
            Console.WriteLine($"------------> Page : {pageNumber} <------------");
            return true;
        }
    }
}
