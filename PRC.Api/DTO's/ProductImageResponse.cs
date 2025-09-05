namespace PRC.Api.DTO_s
{
    public class ProductImageResponse
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public int SortOrder { get; set; }
    }
}
