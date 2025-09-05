namespace miniproj.Domain.Entities
{
    using System;
    using miniproj.Domain.ValueObjects;

    public class User
    {
        public Guid Id { get; }
        public string Name { get; }
        public Email Email { get; }
        public int OrderCount { get; set; } = 0;
        public Money Balance { get; set; }
        public User(Guid userId, string name, Email email, Money s)
        {
            this.Id = userId;
            this.Name = name;
            this.Email = email;
            this.Balance = s;
        }
    }
}