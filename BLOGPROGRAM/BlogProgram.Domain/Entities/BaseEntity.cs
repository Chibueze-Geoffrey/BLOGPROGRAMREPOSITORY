namespace BlogProgram.Domain.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
