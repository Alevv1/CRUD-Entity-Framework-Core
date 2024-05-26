using System.ComponentModel.DataAnnotations;

namespace TestProyecto.Models
{
    public class Contacto
    {


        //Si quiero hacer cambios, simplemente pongo en la consola: " add-migration "  despues update-database

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }


        public DateTime  FechaCreacion { get; set;}
    }


}
