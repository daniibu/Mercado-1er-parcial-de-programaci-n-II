using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MERCADO2.Core.Modelos
{
    public class Marca
    {
        [Key]
        public int MarcaId { get; set; }
        [Required]//es para que no pueda ser nulo
        [StringLength(30)]//para el nombre de la marca
        [Display(Name = "Ingrese nombre de la marca")]
        public string? NombreMarca { get; set; }
        public int ProductoId { get; set; }
        //public ICollection<Proveedor>?Proveedores { get; set; }
        //Proveedores es una propiedad de navegación, Las propiedades de navegacion contienen otras entidades
        //relacionadas con esta entidad. En este caso, PROVEEDORES en la entidad Marca contiene todas las entidades
        //de PROVEEDOR que están relacionados con Marca
        //Proveedor tiene/trabaja con muchas marcas
    }
}
