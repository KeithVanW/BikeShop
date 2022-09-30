namespace BikeShop.Domain
{
    public class Bike
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}