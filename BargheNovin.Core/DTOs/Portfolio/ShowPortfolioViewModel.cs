namespace BargheNovin.Core.DTOs.Portfolio
{
    public class ShowPortfolioViewModel
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public CategoryViewModel Category { get; set; }
        public string Description { get; set; }
    }
}
