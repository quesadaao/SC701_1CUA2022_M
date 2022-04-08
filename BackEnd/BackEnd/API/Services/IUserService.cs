using API.DataModels;

namespace API.Services
{
    public interface IUserService
    {
        bool IsValid(LoginRequestDTO req);
    }
}
