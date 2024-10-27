namespace radlab4._0.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }
}