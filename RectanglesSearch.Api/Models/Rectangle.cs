using System.ComponentModel.DataAnnotations;

namespace RectanglesSearch.Api.Models
{
    public class Rectangle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int XCoordinate { get; set; }
        [Required]
        public int YCoordinate { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
    }
}
