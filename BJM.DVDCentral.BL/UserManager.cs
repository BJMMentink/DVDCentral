using System.Security.Cryptography;
using System.Text;

namespace BJM.DVDCentral.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Could not login with those credentials. IP Address saved.")
        {

        }
        public LoginFailureException(string message) : base(message)
        {

        }
    }
    public static class UserManager
    {
        public static string GetHash(string password)
        {
            using (var hasher = SHA1.Create())
            {
                var hashbytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }
        public static int DeleteAll()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
                    return dc.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserId))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (DVDCentralEntities dc = new DVDCentralEntities())
                        {
                            tblUser tbluser = dc.tblUsers.FirstOrDefault(u => u.UserId == user.UserId);
                            if (tbluser != null)
                            {
                                if (tbluser.Password == GetHash(user.Password))
                                {
                                    user.Id = tbluser.Id;
                                    user.FirstName = tbluser.FirstName;
                                    user.LastName = tbluser.LastName;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException();
                                }
                            }
                            else
                            {
                                throw new LoginFailureException("UserId was not found.");
                            }
                        }
                    }
                    else
                    {
                        throw new LoginFailureException("Password was not set");
                    }
                }
                else
                {
                    throw new LoginFailureException("UserId was not set");
                }
            }
            catch (LoginFailureException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Seed()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                if (!dc.tblUsers.Any())
                {
                    Insert(new User()
                    {
                        UserId = "bment",
                        FirstName = "Ben",
                        LastName = "Mentink",
                        Password = "123Dev"
                    });

                    Insert(new User()
                    {
                        UserId = "bfoote",
                        FirstName = "Brian",
                        LastName = "Foote",
                        Password = "maple"
                    });
                }
            }
        }
        public static int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblUser entity = new tblUser();
                    entity.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(s => s.Id) + 1 : 1;
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;
                    entity.UserId = user.UserId;
                    entity.Password = GetHash(user.Password);
                    user.Id = entity.Id;
                    dc.tblUsers.Add(entity);
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
        public static int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser entity = dc.tblUsers.FirstOrDefault(u => u.Id == user.Id);

                    if (entity != null)
                    {
                        entity.FirstName = user.FirstName;
                        entity.LastName = user.LastName;
                        entity.UserId = user.UserId;
                        entity.Password = GetHash(user.Password);

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("User not found for update.");
                    }
                    return results;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Delete(int userId, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser user = dc.tblUsers.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        dc.tblUsers.Remove(user);
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("User not found for deletion.");
                    }
                    return results;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<User> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    var users = dc.tblUsers.Select(u => new User
                    {
                        Id = u.Id,
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName
                    }).ToList();

                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static User LoadById(int userId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser user = dc.tblUsers.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        return new User
                        {
                            Id = user.Id,
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName
                        };
                    }
                    else
                    {
                        throw new InvalidOperationException("User not found.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
