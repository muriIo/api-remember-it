using api_remember_it.Data;
using api_remember_it.Interfaces;
using api_remember_it.Models;

namespace api_remember_it.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RememberItDbContext _rememberItDbContext;

        public UserRepository(RememberItDbContext rememberItDbContext)
        {
            _rememberItDbContext = rememberItDbContext;
        }

        public List<User> GetAll()
        {
            return _rememberItDbContext.User.ToList(); ;
        }

        public User? GetById(int id)
        {
            return _rememberItDbContext.User.Find(id);
        }

        public User? Create(User user)
        {
            var dbUser = _rememberItDbContext.User.Add(user);
            _rememberItDbContext.SaveChanges();
            return dbUser.Entity;
        }

        public User? Update(User user)
        {
            var dbUser = _rememberItDbContext.User.Update(user);
            _rememberItDbContext.SaveChanges();
            return dbUser.Entity;
        }

        public void Delete(User user)
        {
            _rememberItDbContext.User.Remove(user);
            _rememberItDbContext.SaveChanges();
        }

        public User? GetUserByEmail(string email) {
            return _rememberItDbContext.User.FirstOrDefault(user => user.Email == email);
        }
    }
}
