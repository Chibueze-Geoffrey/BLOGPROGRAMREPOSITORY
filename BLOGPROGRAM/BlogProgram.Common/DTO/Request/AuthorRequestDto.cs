using System.ComponentModel.DataAnnotations;

namespace BlogProgram.Common.DTO.Request
{
    public class AuthorRequestDto
    {
        public string Id { get; set; }
        [Required]
        public string FirstName  { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
