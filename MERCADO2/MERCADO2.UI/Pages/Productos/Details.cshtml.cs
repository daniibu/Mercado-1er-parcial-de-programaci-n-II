using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MERCADO2.Core.Modelos;
using MERCADO2.UI.Data;

namespace MERCADO2.UI.Pages.Productos
{
    public class DetailsModel : PageModel
    {
        private readonly MERCADO2.UI.Data.MERCADO2Context _context;

        public DetailsModel(MERCADO2.UI.Data.MERCADO2Context context)
        {
            _context = context;
        }

      public Producto Producto { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Las siguientes líneas sirven para que se muestren los detalles de la marca del producto también.
             var producto = await _context.Producto
                .Include(s => s.Marca)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductoId == id);

            if (producto == null)
            {
                return NotFound();
            }
            else 
            {
                Producto = producto;
            }
            return Page();
        }
    }
}
