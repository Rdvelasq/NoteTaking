using System.ComponentModel.DataAnnotations;

namespace NoteTaking.Models
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required] 
        public string Created { get; set; } = DateTime.Now.ToString("MM/dd/yyyy");

    }
}
