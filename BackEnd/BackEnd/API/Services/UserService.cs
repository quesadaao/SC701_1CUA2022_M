using API.DataModels;

namespace API.Services
{
    public class UserService : IUserService
        {
        // Prueba de simulación, el valor predeterminado es verificación artificial efectiva
        public bool IsValid(LoginRequestDTO req)
            {
            // Quemar la informacion 
            // Ir base de datos para revisar si exite un usuario

            if (true)
                {
                return true;
                }
            else 
                { 
                return false; 
                
                }

            }
        }
}
