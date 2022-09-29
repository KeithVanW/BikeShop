namespace BikeShop.Models.Shop
{
    public class ShopListViewModel
    {
        public IEnumerable<ShopListItem> Items { get; set; }
        public string BannerUrl { get; private set; }

        public string Title { get; } = "Overview";

        public ShopListViewModel()
        {
            Random random = new Random();
            int value = random.Next(0, bannerImages.Length);
            BannerUrl = bannerImages[value];
        }

        private string[] bannerImages = new string[]
        {
            "/photos/banner/cliff.jpg",
            "/photos/banner/fjord.jpg",
            "/photos/banner/northernlight.jpg",
            "/photos/banner/road.jpg"
        };
    }
}