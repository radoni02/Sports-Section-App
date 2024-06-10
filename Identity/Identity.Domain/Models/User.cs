using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models;

public class User
{
    private User(Guid id, string firstName, string lastName, string email)
    {
        Firstname = firstName;
        LastName = lastName;
        Email = email;
    }
    public string Firstname { get;private set; }
    public string LastName { get;private set; }
    public  string Email { get;private set; }
    public  string Password { get;private set; }
    public Guid IdentityId { get; private set; }

    public static User CreateUser(string firstName, string lastName, string email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);
        return user;
    }

    public void SetIdentityId(Guid identityId)
    {
        IdentityId = identityId;
    }
}
