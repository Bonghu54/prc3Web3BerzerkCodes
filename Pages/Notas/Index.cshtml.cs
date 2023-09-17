using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prc3Web3BerzerkCodes.Data;
using prc3Web3BerzerkCodes.Modelos;

namespace prc3Web3BerzerkCodes.Pages.Notas
{
    public class IndexModel : PageModel
    {
        private readonly prc3Web3BerzerkCodes.Data.prc3Web3BerzerkCodesContext _context;

        public IndexModel(prc3Web3BerzerkCodes.Data.prc3Web3BerzerkCodesContext context)
        {
            _context = context;
        }

        public IList<Nota> Nota { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Nota != null)
            {
                Nota = await _context.Nota
                .Include(n => n.Asignatura)
                .Include(n => n.Estudiante).ToListAsync();
            }
        }
    }
}
