using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [MaxLength(length:200)]
        public string Description { get; set; }
        public string Language { get; set; }
        [Required, MaxLength(length:13)]
        public string ISBN { get; set; }
        [Required, DataType(DataType.Date),Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }
        [Required, DataType(DataType.Currency)]
        public int Price { get; set; }
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
   

    }
}
