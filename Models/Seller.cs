namespace radlab4._0.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }
}