using API.entities;

namespace API.Interfaces
{
    public interface ITokenInterface
    {
        string CreateToken(Appusers user);
    }
}