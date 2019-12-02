using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GroceryStores.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace GroceryStores.Pages.Surveys
{
    public class CreatePageModel : PageModel
    {
        private readonly IHostingEnvironment _environment;
        public CreatePageModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public GroceryStoreSurvey surveyList { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string survey = surveyList.firstName + "," + surveyList.lastName + "," + surveyList.mobile + "," + surveyList.email + ","  + surveyList.zip + "," + surveyList.stores;
            string path = Path.Combine(_environment.ContentRootPath, "FoodSurveys.txt");

            System.IO.File.AppendAllText(path, survey + Environment.NewLine);

            return RedirectToPage("./Index");
        }
    }
}