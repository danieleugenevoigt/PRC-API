using System.ComponentModel.DataAnnotations.Schema;

namespace PRC.Core.Entities
{
    [Table("products")]
    public class Products
    {
        [Column("id")]
        public long Id { get; set; }  // Changed to long to match bigint
        
        [Column("sku")]
        public string Sku { get; set; } = string.Empty;  // Changed to string to match text
        
        [Column("supplier_code")]
        public string? SupplierCode { get; set; }  // Changed to string and nullable
        
        [Column("title")]
        public string Title { get; set; } = string.Empty;
        
        [Column("description")]
        public string? Description { get; set; }  // Made nullable
        
        [Column("quantity_in_stock")]
        public int Qty { get; set; }
        
        [Column("price")]
        public decimal? Price { get; set; }  // Changed to decimal and nullable
        
        [Column("is_active")]
        public bool IsActive { get; set; }
        
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        // Navigation property - EF will use this for the many-to-many relationship
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        
        // Note: search_text is auto-generated, so we might not need to include it
        // [Column("search_text")]
        // public string? SearchText { get; set; } 
    }
}
