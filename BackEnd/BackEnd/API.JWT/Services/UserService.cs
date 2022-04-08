using API.JWT.Models;

namespace API.JWT.Services
    {
        public class UserService : IUserService
        {
            // Prueba de simulación, el valor predeterminado es verificación artificial efectiva
            public bool IsValid(LoginRequestDTO req)
            {
                //Se debe agregar la verificacion hacia la base de datos 


                return true;
            }
        }
    }
