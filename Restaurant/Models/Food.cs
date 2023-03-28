using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Food
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Név { get; set; }
        [Required]
        public int Tápérték { get; set; }
        [Required]
        public string Kategória { get; set; }
        [Required]
        public int Ár { get; set; }
        [StringLength(200)]
        public string? ImageFileName { get; set; }


        public string? ContentType { get; set; }

        public byte[]? Data { get; set; }
        public Food()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
