using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryStores.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GroceryStores.Pages.Surveys
{
    public class CreateModel : PageModel
    {
        private readonly IHostingEnvironment _environment;
        public CreateModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GroceryStoreSurvey GroceryStoreSurvey { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string survey = GroceryStoreSurvey.firstName + "," + GroceryStoreSurvey.lastName + "," + GroceryStoreSurvey.mobile + "," + GroceryStoreSurvey.email + "," + GroceryStoreSurvey.zip + "," + GroceryStoreSurvey.stores;
            string path = Path.Combine(_environment.ContentRootPath, "Surveys.txt");

            System.IO.File.AppendAllText(path, survey + Environment.NewLine);

            return RedirectToPage("./Index");

           
        }
    }
}