using System.ComponentModel.DataAnnotations.Schema;

namespace PRC.Core.Entities
{
    [Table("product_images")]
    public class ProductImage
    {
        [Column("id")]
        public long Id { get; set; }
        
        [Column("product_id")]
        public long ProductId { get; set; }
        
        [Column("image_url")]
        public string ImageUrl { get; set; } = string.Empty;
        
        [Column("alt_text")]
        public string? AltText { get; set; }
        
        [Column("sort_order")]
        public int SortOrder { get; set; }
        
        // Navigation property back to Products
        public Products Product { get; set; } = null!;
    }
}
