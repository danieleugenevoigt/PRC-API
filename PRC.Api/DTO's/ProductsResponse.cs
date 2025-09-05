namespace PRC.Api.DTO_s
{
    public class ProductResponse
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
        public IEnumerable<ProductImageResponse> ProductImages { get; set; } = new List<ProductImageResponse>(); 
        public IEnumerable<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();
    }
}
