


namespace BJM.DVDCentral.BL
{
    public class CustomerManager : GenericManager<tblCustomer>
    {
        public CustomerManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }
        public static int Insert(Customer customer, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblCustomer entity = new tblCustomer();
                    entity.Id = Guid.NewGuid();
                    entity.FirstName = customer.FirstName;
                    entity.LastName = customer.LastName;
                    entity.Address = customer.Address;
                    entity.City = customer.City;
                    entity.State = customer.State;
                    entity.ZIP = customer.ZIP;
                    entity.Phone = customer.Phone;
                    entity.UserId = customer.UserId;
                    customer.Id = entity.Id;
                    dc.tblCustomers.Add(entity);
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
        public static int Update(Customer customer, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == customer.Id);
                    if (entity != null)
                    {
                        entity.FirstName = customer.FirstName;
                        entity.LastName = customer.LastName;
                        entity.Address = customer.Address;
                        entity.City = customer.City;
                        entity.State = customer.State;
                        entity.ZIP = customer.ZIP;
                        entity.Phone = customer.Phone;
                        entity.UserId = customer.UserId;
                        customer.Id = entity.Id;
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
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblCustomers.Remove(entity);
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
        public static Customer LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Customer
                        {
                            Id = entity.Id,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Address = entity.Address,
                            City = entity.City,
                            State = entity.State,
                            ZIP = entity.ZIP,
                            Phone = entity.Phone,
                            UserId = entity.UserId
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
        public static List<Customer> Load()
        {
            try
            {
                List<Customer> list = new List<Customer>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblCustomers
                     select new
                     {
                         s.Id,
                         s.FirstName,
                         s.LastName,
                         s.Address,
                         s.City,
                         s.State,
                         s.ZIP,
                         s.Phone,
                         s.UserId
                     })
                     .ToList()
                     .ForEach(customer => list.Add(new Customer
                     {
                         Id = customer.Id,
                         FirstName = customer.FirstName,
                         LastName = customer.LastName,
                         Address = customer.Address,
                         City = customer.City,
                         State = customer.State,
                         ZIP = customer.ZIP,
                         Phone = customer.Phone,
                         UserId = customer.UserId

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
