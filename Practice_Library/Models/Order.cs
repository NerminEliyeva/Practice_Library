namespace Practice_Library.Models
{
    /// <summary>
    /// Bu sinif satış proseslərini idarə edir.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Sifarişin identifikasiya nömrəsi
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Sifariş olunan kitabların siyahısı
        /// </summary>
        public List<Book> Books { get; set; }
        /// <summary>
        /// Sifariş olunan kitabların umumi qiyməti
        /// </summary>
        private decimal TotalPrice { get; set; }
        /// <summary>
        /// Sifariş tarixi
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Satış prosesini həyata keçirən metod: Sifariş olunan kitabların qiymətlərini hesablayır.
        /// </summary>
        public void ProcessSale()
        {
            TotalPrice = Books.Sum(x => x.Price);
            Date = DateTime.Now;
            Console.WriteLine("Satış prosesi uğurla həyata keçirildi.");
            Console.WriteLine($"Umumi mebleg : {TotalPrice}");
        }

    }
}
