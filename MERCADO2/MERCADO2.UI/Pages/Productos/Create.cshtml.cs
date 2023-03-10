using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MERCADO2.Core.Modelos;
using MERCADO2.UI.Data;

namespace MERCADO2.UI.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly MERCADO2.UI.Data.MERCADO2Context _context;

        public CreateModel(MERCADO2.UI.Data.MERCADO2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Producto Producto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProducto = new Producto();
            if (await TryUpdateModelAsync<Producto>(
            emptyProducto,
            "producto", //Prefijo para el valor del formulario.
            s => s.NombreProducto, s => s.Precio, s => s.Cantidad, s => s.Marca))
            {
                _context.Producto.Add(emptyProducto);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
