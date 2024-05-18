namespace BlogProgram.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string FeaturedImage { get; set; }
        public string AuthorId { get; set; }

        public Author Author { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
