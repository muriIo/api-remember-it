using api_remember_it.DTOs;
using api_remember_it.Interfaces;
using api_remember_it.Models;
using api_remember_it.Utils;

namespace api_remember_it.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        private readonly IUserRepository _userRepository;
        public UserService(ILogger<UserService> logger, IUserRepository userRepository) {
            _logger = logger;
            _userRepository = userRepository;
        }

        public void Register(CreateUserDTO userDTO)
        {
            var dbUser = _userRepository.GetUserByEmail(userDTO.Email);

            if (dbUser != null)
                throw new Exception("User already exists");

            PasswordUtil.CreatePasswordHash(userDTO.Password, out string passwordHash, out string passwordSalt);

            User user = new User();
            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.Birthday = userDTO.Birthday;
            user.ProfilePictureUrl = userDTO.ProfilePictureUrl;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userRepository.Create(user);
        }
    }
}
