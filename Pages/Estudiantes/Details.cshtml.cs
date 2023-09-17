using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prc3Web3BerzerkCodes.Data;
using prc3Web3BerzerkCodes.Modelos;

namespace prc3Web3BerzerkCodes.Pages.Estudiantes
{
    public class DetailsModel : PageModel
    {
        private readonly prc3Web3BerzerkCodes.Data.prc3Web3BerzerkCodesContext _context;

        public DetailsModel(prc3Web3BerzerkCodes.Data.prc3Web3BerzerkCodesContext context)
        {
            _context = context;
        }

      public Estudiante Estudiante { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante.FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }
            else 
            {
                Estudiante = estudiante;
            }
            return Page();
        }
    }
}
