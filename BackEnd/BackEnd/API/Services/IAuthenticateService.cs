using API.DataModels;

namespace API.Services
    {
        public interface IAuthenticateService
        {
            bool IsAuthenticated(LoginRequestDTO request, out string token);
        }
    }
