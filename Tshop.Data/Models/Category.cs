namespace Tshop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        // Required column in DB
        public string Name { get; set; } = null!;

        // Navigation property
        public List<CategoryTranslate> translations { get; set; } = new();
    }
}