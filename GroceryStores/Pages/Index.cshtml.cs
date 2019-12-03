using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessOwnerDetails;
using Microsoft.Extensions.Logging;

/*Grocery Stores Project Combines two JSON files.
 * One file named BusinessOwner has the information about business owners and their titles
 * Another file named GroceryStore has information like address, location, zip etc  
 * The field common to both of these JSON is Account Number
 * By matching the Account Number we can determine the owner name and nearby grocery stores and display the information in a table
 */
namespace GroceryStores.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public void OnGet()
        {
        }
    }
}
