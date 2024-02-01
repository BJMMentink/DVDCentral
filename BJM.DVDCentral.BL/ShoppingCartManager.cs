namespace BJM.DVDCentral.BL
{
    public static class ShoppingCartManager
    {
        public static void Add(ShoppingCart cart, Movie movie)
        {
            if (cart != null)
            {
                cart.Items.Add(movie);
            }
        }
        public static void Remove(ShoppingCart cart, Movie movie)
        {
            if (cart != null)
            {
                cart.Items.Remove(movie);
            }
        }
        public static void Checkout(ShoppingCart cart, Guid UserId, Guid CustId)
        {
            if (cart == null || cart.Items.Count == 0)
            {
                return;
            }

            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                Order order = new Order
                {
                    CustomerId = CustId,
                    UserId = UserId,
                    OrderDate = DateTime.Now,
                    ShipDate = DateTime.Now.AddDays(3),
                    
                };
                foreach (var item in cart.Items)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        MovieId = item.Id,
                        OrderId = Guid.NewGuid(),
                        Quantity = 1,
                        Cost = item.Cost,

                    };
                    order.Items.Add(orderItem);
                    tblMovie entity = dc.tblMovie.FirstOrDefault(s => s.Id == item.Id);
                    if (entity != null && entity.InStkQty > 0)
                    {
                        entity.InStkQty--;
                    }
                }
                dc.SaveChanges();

                OrderManager.Insert(order);
            }

        }


    }
    
}
