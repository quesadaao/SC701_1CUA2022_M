using API.DataModels;

namespace API.Services
{
    public class UserService : IUserService
        {
        // Prueba de simulación, el valor predeterminado es verificación artificial efectiva
        public bool IsValid(LoginRequestDTO req)
            {
            return true;
            }
        }
}
