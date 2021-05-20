using System.ComponentModel.DataAnnotations;

namespace cs_knights_tale.Models
{
    public class Knight
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public int KingdomId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string ImgUrl { get; set; }

    }
}