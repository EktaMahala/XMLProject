using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryStores.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GroceryStores.Pages.Surveys
{
    public class IndexModel : PageModel
    {
        private readonly IHostingEnvironment _environment;

        public IndexModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IList<GroceryStoreSurvey> GroceryStoreSurveys = new List<GroceryStoreSurvey>();

        public void OnGet()
        {
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "Surveys.txt");
            StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                GroceryStoreSurvey survey = new GroceryStoreSurvey();
                survey.firstName = data[0];
                survey.lastName = data[1];
                survey.mobile = data[2];
                survey.email = data[3];
                survey.zip = data[4];
                survey.stores = data[5];
                GroceryStoreSurveys.Add(survey);
            }
            file.Close();
        }
    }
}
