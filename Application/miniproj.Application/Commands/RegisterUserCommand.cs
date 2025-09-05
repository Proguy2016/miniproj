using MediatR;
namespace miniproj.Application.Commands
{
    public class RegisterUserCommand : IRequest
    {   
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
        public decimal InitialBalance { get; }
        public string Currency { get; }

        public RegisterUserCommand(string name, string email, decimal initialBalance, string currency)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            InitialBalance = initialBalance;
            Currency = currency;
        }
    }
}