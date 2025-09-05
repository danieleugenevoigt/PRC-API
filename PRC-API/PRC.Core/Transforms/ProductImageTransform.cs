namespace PRC.Core.Transforms
{
    public class ProductImageTransform
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public int SortOrder { get; set; }
    }
}
