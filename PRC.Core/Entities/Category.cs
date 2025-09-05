using System.ComponentModel.DataAnnotations.Schema;

namespace PRC.Core.Entities
{
    [Table("categories")]
    public class Category
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("slug")]
        public string Slug { get; set; } = string.Empty;

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
