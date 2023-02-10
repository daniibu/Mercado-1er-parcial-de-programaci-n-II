using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MERCADO2.Core.Modelos
{
    public class Producto
    {
        //PruductoId= PK/Clave Principal
        [Key]
        public int ProductoId { get; set; }
        [Required]
        [StringLength(30)]//para el nombre del producto
        [Display(Name = "Nombre del producto")]
        public string? NombreProducto { get; set; }
        public string? Precio { get; set; }
        public string? Cantidad { get; set; }
        public Marca? Marca { get; set; }
        //un producto tiene 1 sola marca
    }
}
