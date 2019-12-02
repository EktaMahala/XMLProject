using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryStores.Pages
{
    public class SearchGroceryStoresModel : PageModel
    {
        public void OnGet()
        {
            SearchCompleted = false;
        }
        [BindProperty]
        public long Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<BusinessOwnerDetails.BusinessOwner> businessOwners { get; set; }
        public ICollection<GroceryStore> groceryStores { get; set; }

        public void OnPost()
        {

            using (var webClient = new WebClient())
            {
                String businessOwnerjsonString = webClient.DownloadString("https://data.cityofchicago.org/resource/r5kz-chrr.json");
                businessOwners = BusinessOwnerDetails.BusinessOwner.FromJson(businessOwnerjsonString);
                
                ViewData["businessOwners"] = businessOwners;

                String firejsonString = webClient.DownloadString("https://data.cityofchicago.org/resource/53t8-wyrc.json");
                groceryStores = GroceryStore.FromJson(firejsonString);
                
                ViewData["groceryStores"] = groceryStores;
            }
            businessOwners = businessOwners.Where(x => x.ZipCode == Search).ToArray();
            groceryStores = groceryStores.Where(x => x.ZipCode == Search).ToArray();
            SearchCompleted = true;
        }
    }
}