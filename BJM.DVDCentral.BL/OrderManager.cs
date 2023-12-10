using System.Xml.Linq;
using BJM.DVDCentral.PL;
using BJM.DVDCentral.BL.Models;
using System.Xml;
using Microsoft.EntityFrameworkCore.Storage;

namespace BJM.DVDCentral.BL
{
    public class OrderManager
    {
        public static int Insert(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrder entity = new tblOrder();
                    entity.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(s => s.Id) + 1 : 1;
                    entity.ShipDate = order.ShipDate;
                    entity.CustomerId = order.CustomerId;
                    entity.UserId = order.UserId;
                    entity.OrderDate = order.OrderDate;
                    foreach (OrderItem orderItem in order.Items)
                    {
                        OrderItemManager.Insert(orderItem, rollback);
                    }

                    order.Id = entity.Id;
                    dc.tblOrders.Add(entity);
                    results = dc.SaveChanges();
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Update(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == order.Id);
                    if (entity != null)
                    {
                        entity.ShipDate = order.ShipDate;
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblOrders.Remove(entity);
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Order LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        Order order = new Order
                        {
                            Id = entity.Id,
                            ShipDate = entity.ShipDate,
                            CustomerId = entity.CustomerId,
                            UserId = entity.UserId,
                            OrderDate = entity.OrderDate,
                            Items = new List<OrderItem>() 
                        };

                       
                        var orderItems = OrderItemManager.LoadByOrderId(entity.Id);
                        foreach (var item in orderItems)
                        {
                            order.Items.Add(item); 
                        }

                        return order;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Order> Load()
        {
            try
            {
                List<Order> list = new List<Order>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    var orders = (from s in dc.tblOrders
                                  select new
                                  {
                                      s.Id,
                                      s.CustomerId,
                                      s.UserId,
                                      s.OrderDate,
                                      s.ShipDate
                                  }).ToList();

                    orders.ForEach(order => list.Add(new Order
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        UserId = order.UserId,
                        OrderDate = order.OrderDate,
                        ShipDate = order.ShipDate
                    }));
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
