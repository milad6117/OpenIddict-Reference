using System;
using System.Collections.Generic;
using System.Text;

namespace OpenIddict.Reference.Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get;private set; } = default;
        public string FullName { get; private set; } = default;
        public string Email { get; private set; } = default;
        public string PasswordHash { get; private set; } = default;
        public string Role { get; private set; } = "User";

        private User() { }

        public User(string fullName, string email, string passwordHash, string role = "User")
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
