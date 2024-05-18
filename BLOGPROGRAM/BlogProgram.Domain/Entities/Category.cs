namespace BlogProgram.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
