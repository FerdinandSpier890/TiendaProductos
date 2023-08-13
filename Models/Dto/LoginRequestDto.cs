using System.ComponentModel.DataAnnotations;

namespace TiendaProductos.Models.Dto
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Nombre de Usuario Requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Contraseña Requerido")]
        public string Password { get; set; }
    }
}
