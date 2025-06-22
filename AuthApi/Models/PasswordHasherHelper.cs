using Microsoft.AspNetCore.Identity;

namespace AuthApi.Models {
    public interface IPasswordHasherHelper {
        string HashPassword(User user, string password);
        bool VerifyPassword(User user, string hashedPassword, string password);
    }

    public class PasswordHasherHelper : IPasswordHasherHelper {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordHasherHelper(IPasswordHasher<User> passwordHasher){
            this._passwordHasher = passwordHasher;
        }

        public string HashPassword(User user, string password) {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string hashedPassword, string password) {
            var result = _passwordHasher.VerifyHashedPassword(user,  hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
