namespace Practice_Library.Models
{
    /// <summary>
    /// Kitab sinifi
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Kitab ucun unikal kod
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Kitabın adı
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Müəllifin adı
        /// </summary>
        public string? AuthorName { get; set; }
        /// <summary>
        /// Səhifə sayı
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Qiymət
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Kitabın kodu
        /// </summary>
        public string? Code;
        /// <summary>
        /// Kitabın adının baş hərfləri və sıra nömrəsine uygun kod yaradir
        /// </summary>
        /// <returns></returns>
        public string GenerateCode()
        {
                string[] capitalCases = Name.Split(" ").Select(x => x[..1]).ToArray();
                string joined = string.Join("", capitalCases);
                Code = $"{joined}{Id}";
                return Code;
        }
    }
}
