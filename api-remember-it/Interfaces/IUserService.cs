using api_remember_it.DTOs;

namespace api_remember_it.Interfaces
{
    public interface IUserService
    {
        public void Register(CreateUserDTO user);
    }
}
