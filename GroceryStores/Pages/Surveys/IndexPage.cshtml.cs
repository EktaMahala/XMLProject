using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GroceryStores.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GroceryStores.Pages.Surveys
{
    public class IndexPageModel : PageModel
    {
        private readonly IHostingEnvironment _environment;

        public IndexPageModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IList<GroceryStoreSurvey> surveyList = new List<GroceryStoreSurvey>();
        public void OnGet()
        {
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "Surveys.txt");
            StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                GroceryStoreSurvey gs = new GroceryStoreSurvey();
                gs.firstName = data[0];
                gs.lastName = data[1];
                gs.mobile = data[2];
                gs.email = data[3];
                gs.zip = data[4];
                gs.stores = data[5];
               

                surveyList.Add(gs);
            }
            file.Close();

        }
    }
}