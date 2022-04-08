using API.JWT.Models;

namespace API.JWT.Services
    {
        public interface IAuthenticateService
        {
            bool IsAuthenticated(LoginRequestDTO request, out string token);
        }
    }
