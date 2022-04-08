using API.JWT.Models;

namespace API.JWT.Services
{
    public interface IUserService
    {
        bool IsValid(LoginRequestDTO req);
    }
}
