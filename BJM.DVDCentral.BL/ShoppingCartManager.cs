using BJM.DVDCentral.BL.Models;
using BJM.DVDCentral.PL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public static void Checkout(ShoppingCart cart)
        {
            if (cart == null || cart.Items.Count == 0)
            {
                return;
            }

            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                Order order = new Order
                {
                    CustomerId = 1,
                    UserId = 1, 
                    OrderDate = DateTime.Now,
                    ShipDate = DateTime.Now.AddDays(3)
                };
                foreach (var item in cart.Items)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        MovieId = item.Id,
                        Quantity = 1 
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
