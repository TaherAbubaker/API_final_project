using System.Text.Json.Serialization;

namespace Tshop.Data.Models
{
    public class CategoryTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Language { get; set; } = "en";

        public int CategoryId { get; set; }

        [JsonIgnore] // <-- prevents serialization cycle
        public Category Category { get; set; } = null!;
    }
}