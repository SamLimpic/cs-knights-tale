using System.ComponentModel.DataAnnotations;

namespace cs_knights_tale.Models
{
    public class Kingdom
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int LordId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Garrison { get; set; }

        public string ImgUrl { get; set; }

    }
}