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
    public class DeleteModel : PageModel
    {
        private readonly MERCADO2.UI.Data.MERCADO2Context _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(MERCADO2.UI.Data.MERCADO2Context context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Producto Producto { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false) 
        {
            if (id == null)
            {
                return NotFound();
            }
            Producto = await _context.Producto
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (Producto == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            try
            {

                _context.Producto.Remove(producto);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

            }
            catch (DbUpdateException ex) 
            {
                _logger.LogError(ex, ErrorMessage);
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
            
        }
    }
}
