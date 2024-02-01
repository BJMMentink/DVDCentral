﻿namespace BJM.DVDCentral.BL
{
    public class OrderItemManager
    {
        public static int Insert(OrderItem orderItem, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrderItem entity = new tblOrderItem();
                    entity.Id = Guid.NewGuid();
                    entity.OrderId = orderItem.OrderId;
                    entity.MovieId = orderItem.MovieId;
                    entity.Quantity = orderItem.Quantity;
                    entity.Cost = orderItem.Cost;

                   
                    orderItem.Id = entity.Id;
                    dc.tblOrderItems.Add(entity);
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
        public static int Update(OrderItem orderItem, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(s => s.Id == orderItem.Id);
                    if (entity != null)
                    {
                        entity.OrderId = orderItem.OrderId;
                        entity.MovieId = orderItem.MovieId;
                        entity.Quantity = orderItem.Quantity;
                        entity.Cost = orderItem.Cost;
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
        public static int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblOrderItems.Remove(entity);
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
        public static OrderItem LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new OrderItem
                        {
                            Id = entity.Id,
                            OrderId = entity.OrderId,
                            MovieId = entity.MovieId,
                            Quantity = entity.Quantity,
                            Cost = entity.Cost

                        };
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
        public static List<OrderItem> LoadByOrderId(Guid orderid)
        {
            try
            {
                List<OrderItem> list = new List<OrderItem>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    
                    var orderItems = (from s in dc.tblOrderItems
                                      where s.OrderId == orderid
                                      select new OrderItem
                                      {
                                          Id = s.Id,
                                          OrderId = s.OrderId,
                                          MovieId = s.MovieId,
                                          Quantity = s.Quantity,
                                          Cost = s.Cost
                                      }).ToList();

                    list.AddRange(orderItems); 
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static List<OrderItem> Load(Guid? CustomerId = null)
        {
            try
            {
                List<OrderItem> list = new List<OrderItem>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblOrderItems
                     where s.Id == CustomerId || CustomerId == null
                     select new
                     {
                         s.Id,
                         s.OrderId,
                         s.MovieId,
                         s.Quantity,
                         s.Cost
                     })
                     .ToList()
                     .ForEach(orderItem => list.Add(new OrderItem
                     {
                         Id = orderItem.Id,
                         OrderId = orderItem.OrderId,
                         MovieId = orderItem.MovieId,
                         Quantity = orderItem.Quantity,
                         Cost = orderItem.Cost
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
