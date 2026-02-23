using Users.Domain.Enums;
using Users.Domain.Exceptions;
using Users.Domain.Resources;

namespace Users.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; } = UserRole.User;

        public User() { }
        public User(string name, string email, string passwordHash)
        {
            Validate(name, email, passwordHash);

            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        public void Update(string name, string email, string passwordHash)
        {
            Validate(name, email, passwordHash);

            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        public void SetUserAdmin() => Role = UserRole.Admin;

        public void RemoveAdmin() => Role = UserRole.User;

        private void Validate(string name, string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new DomainException(ExceptionMessages.NameException);
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(ExceptionMessages.EmailEmptyException);
            }

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new DomainException(ExceptionMessages.PasswordEmptyException);
            }
        }
    }
}
