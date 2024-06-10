namespace Identity.Api.Dtos;

public sealed record RegisterUserRequest(string Email, string FirstName, string LastName, string Password);
