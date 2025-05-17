using Microsoft.AspNetCore.Mvc;

namespace TFGApi.Models;

public record class User(
    string? id,
    string usuario,
    string email,
    string password,
    int total_rings,
    Characters? characters
)
{
    public static implicit operator User(ActionResult<User> v)
    {
        throw new NotImplementedException();
    }
}
