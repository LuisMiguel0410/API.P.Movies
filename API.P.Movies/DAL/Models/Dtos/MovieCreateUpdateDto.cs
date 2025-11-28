using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models.Dtos
{
    public class MovieCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la pelicula es obligatoría.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración de la pelicula es obligatoría.")]
        [Range(1, int.MaxValue, ErrorMessage = "La duración debe ser mayor que 0.")] //1 significa que la duracion minima es 1 minuto, int.MaxValue es el valor maximo que puede tener un entero
        public int? Duration { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "La clasificación de la pelicula es obligatoría.")]
        [MaxLength(10, ErrorMessage = "El número máximo de caracteres es de 10.")]
        public string Clasification { get; set; }
    }


}
