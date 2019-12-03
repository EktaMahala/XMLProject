using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryStores.Pages
{
    public class AutoCompleteModel : PageModel
    {

        [BindProperty]
        private string Term { get; set; }
        private IList<string> craftNames = new List<string>();
        public JsonResult OnGet()
        {
            Term = HttpContext.Request.Query["term"];

            addZip("60614");
            addZip("60609");
            addZip("60642");
            addZip("60617");
            addZip("60613");



            return new JsonResult(craftNames);

        }
        private void addZip(string addZip)
        {
            string lowername = addZip.ToLower();
            string lowerterm = Term.ToLower();
            if (lowername.Contains(lowerterm))
            {
                craftNames.Add(addZip);
            }
        }
    }
}
