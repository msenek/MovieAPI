using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class MovieRequestDto
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        [Range (0, 5)]
        public int MovieReview { get; set; }
        [Required]

        public int MovieDate { get; set; }
        [Required]
        [Range (0, 18)]
        public int MovieAgeRange { get; set; }
    }

}