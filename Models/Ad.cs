using System.ComponentModel.DataAnnotations;

namespace radlab4._0.Models
{
    public class Ad
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int SellerId { get; set; }
        public Seller Seller { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}