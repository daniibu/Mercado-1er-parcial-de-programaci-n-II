using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MERCADO2.Core.Modelos
{
    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Ingrese el nombre del proveedor")]
        public string? NombreProveedor { get; set; }
        [Display(Name = "Ingrese numero de telefono")]
        [StringLength(20)]
        public string? TelefonoProveedor { get; set; }
        [Display(Name = "Direccion del proveedor")]
        [StringLength(20)]
        public string? DireccionProveedor { get; set; }
        public Marca? Marca { get; set; }
        //un proveedor tiene muchas marcas
        public ICollection<Marca>? Marcas { get; set; }
    }
}
