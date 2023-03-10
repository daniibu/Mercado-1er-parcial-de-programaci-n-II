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
    public class IndexModel : PageModel
    {
        private readonly MERCADO2.UI.Data.MERCADO2Context _context;

        public IndexModel(MERCADO2.UI.Data.MERCADO2Context context)
        {
            _context = context;
        }

        public IList<Proveedor> Proveedor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Proveedor != null)
            {
                Proveedor = await _context.Proveedor.ToListAsync();
            }
        }
    }
}
