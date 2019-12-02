using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryStores.Models;

namespace GroceryStores.Pages.Surveys
{
    public class CreateModel : PageModel
    {
        private readonly GroceryStores.Models.GroceryStoresContext _context;

        public CreateModel(GroceryStores.Models.GroceryStoresContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GroceryStoreSurvey GroceryStoreSurvey { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GroceryStoreSurvey.Add(GroceryStoreSurvey);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}