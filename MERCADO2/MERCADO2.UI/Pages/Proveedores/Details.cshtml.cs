using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MERCADO2.Core.Modelos;
using MERCADO2.UI.Data;

namespace MERCADO2.UI.Pages.Proveedores
{
    public class DetailsModel : PageModel
    {
        private readonly MERCADO2.UI.Data.MERCADO2Context _context;

        public DetailsModel(MERCADO2.UI.Data.MERCADO2Context context)
        {
            _context = context;
        }

      public Proveedor Proveedor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FirstOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            else 
            {
                Proveedor = proveedor;
            }
            return Page();
        }
    }
}
