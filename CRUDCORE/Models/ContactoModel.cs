using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class ContactoModel
    {
       
        public int IdContacto { get; set; }
        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo telefono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo correo es obligatorio")]
        public string? Correo { get; set; }



    }
}
