using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryStores.Models;

namespace GroceryStores.Pages.Surveys
{
    public class IndexModel : PageModel
    {
        private readonly GroceryStores.Models.GroceryStoresContext _context;

        public IndexModel(GroceryStores.Models.GroceryStoresContext context)
        {
            _context = context;
        }

        public IList<GroceryStoreSurvey> GroceryStoreSurvey { get;set; }

        public async Task OnGetAsync()
        {
            GroceryStoreSurvey = await _context.GroceryStoreSurvey.ToListAsync();
        }
    }
}
