using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prc3Web3BerzerkCodes.Data;
using prc3Web3BerzerkCodes.Modelos;

namespace prc3Web3BerzerkCodes.Pages.Asignaturas
{
    public class DeleteModel : PageModel
    {
        private readonly prc3Web3BerzerkCodes.Data.prc3Web3BerzerkCodesContext _context;

        public DeleteModel(prc3Web3BerzerkCodes.Data.prc3Web3BerzerkCodesContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Asignatura Asignatura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Asignatura == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignatura.FirstOrDefaultAsync(m => m.Id == id);

            if (asignatura == null)
            {
                return NotFound();
            }
            else 
            {
                Asignatura = asignatura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Asignatura == null)
            {
                return NotFound();
            }
            var asignatura = await _context.Asignatura.FindAsync(id);

            if (asignatura != null)
            {
                Asignatura = asignatura;
                _context.Asignatura.Remove(Asignatura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
