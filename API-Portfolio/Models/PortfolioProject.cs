using System.ComponentModel.DataAnnotations;

namespace API_Portfolio.Models
{
    public class PortfolioProject
    {

        public int Id { get; set; }
        [Required] [MaxLength(255)] public string? Name{ get; set; }
        [Required] [MaxLength(1000)] public string? Description { get; set; }
        [Required] [MaxLength(255)] public string? Stack { get; set; }
        [Required] public DateTime Date { get; set; }
        [Required] [MaxLength(1000)] public string? ImageURL { get; set; }
        [Required] public int Months { get; set; }
    }
}
