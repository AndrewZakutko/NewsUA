namespace NewsUA.API.DTOs
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string AuthorName { get; set; }
        public string Information { get; set; }
        public string Status { get; set; }
        public bool IsHot { get; set; }
        public string Type { get; set; }
    }
}