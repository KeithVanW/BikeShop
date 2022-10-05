//using BikeShop.Database;
//using BikeShop.Domain;
//using BikeShop.Domain.Cart;
//using Microsoft.EntityFrameworkCore;

//namespace BikeShop.Logic
//{
//    public class ShoppingCartActions : IDisposable
//    {
//        public string ShoppingCartId { get; set; }

//        private BikeDbContext _bikeDbContext { get; set; }

//        public const string CartSessionKey = "CartId";

        //public void AddToCart(int id)
        //{
        //    // Retrieve the product from the database.
        //    ShoppingCartId = GetCartId();

        //    var cartItem = _bikeDbContext.Bikes.SingleOrDefault(x => x.Id == id);

        //    if (cartItem == null)
        //    {
        //        // Create a new cart item if no cart item exists.
        //        cartItem = new Item
        //        {
        //            ItemId = Guid.NewGuid().ToString(),
        //            ItemId = id,
        //            Bag = ShoppingCartId,
        //            Product = _bikeDbContext.Bikes.SingleOrDefault(
        //           p => p.ItemId == id),
        //            Quantity = 1,
        //            DateCreated = DateTime.Now
        //        };

        //        _bikeDbContext.Bag.Items.Add(cartItem);
        //    }
        //    else
        //    {
        //        // If the item does exist in the cart,
        //        // then add one to the quantity.
        //        cartItem.Quantity++;
        //    }
        //    _db.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    if (_db != null)
        //    {
        //        _db.Dispose();
        //        _db = null;
        //    }
        //}

        //public string GetCartId()
        //{
        //            return Guid.NewGuid().ToString();
        //}

        //public List<CartItem> GetCartItems()
        //{
        //    ShoppingCartId = GetCartId();

        //    return _db.ShoppingCartItems.Where(
        //        c => c.CartId == ShoppingCartId).ToList();
        //}
//    }
//}