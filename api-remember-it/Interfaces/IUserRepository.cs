using api_remember_it.Models;

namespace api_remember_it.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User? GetById(int id);
        public User? Create(User user);
        public User? Update(User user);
        public void Delete(User user);
        public User? GetUserByEmail(string email);
    }
}
