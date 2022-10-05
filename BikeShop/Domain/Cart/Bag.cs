namespace BikeShop.Domain.Cart
{
    public class Bag
    {
        public int BagId { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
