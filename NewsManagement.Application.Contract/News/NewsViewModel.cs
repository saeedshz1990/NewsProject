namespace NewsManagement.Application.Contracts.News
{
    public class NewsViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PublisDate { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }

    }
}
