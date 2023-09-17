﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using prc3Web3BerzerkCodes.Data;
using prc3Web3BerzerkCodes.Modelos;

namespace prc3Web3BerzerkCodes.Pages.Asignaturas
{
    public class CreateModel : PageModel
    {
        private readonly prc3Web3BerzerkCodes.Data.prc3Web3BerzerkCodesContext _context;

        public CreateModel(prc3Web3BerzerkCodes.Data.prc3Web3BerzerkCodesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Asignatura Asignatura { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Asignatura == null || Asignatura == null)
            {
                return Page();
            }

            _context.Asignatura.Add(Asignatura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
