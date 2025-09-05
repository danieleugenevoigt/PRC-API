namespace PRC.Core.Transforms
{
    public class ProductTransform
    {
        public long Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string? SupplierCode { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Qty { get; set; }
        public decimal? Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<ProductImageTransform> ProductImages { get; set; } = new List<ProductImageTransform>();
        public IEnumerable<CategoryTransform> Categories { get; set; } = new List<CategoryTransform>();
    }
}
