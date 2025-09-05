namespace miniproj.Application.Commands;
using MediatR;
using miniproj.Domain.Entities;
using miniproj.Domain.ValueObjects;
using miniproj.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
    
public class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var email = new Email(command.Email);
        var initialBalance = new Money(command.InitialBalance, command.Currency);
        var user = new User(command.Id, command.Name, email, initialBalance);

        await _userRepository.SaveAsync(user);
    }
}