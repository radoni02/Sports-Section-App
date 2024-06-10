using Identity.Application.Abstractions.Authentication;
using Identity.Application.Abstractions.CQRS;
using Identity.Domain.Abstractions;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IAuthenticationService _authenticationService;

    public RegisterUserCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.CreateUser(request.FirstName,request.LastName,request.Email);

        var identityId = await _authenticationService.RegisterAsync(user, request.Password, cancellationToken);
        Guid result;
        if(!Guid.TryParse(identityId, out result))
        {
            throw new Exception();
        }
        user.SetIdentityId(result);
        return user.IdentityId;
    }
}
