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
            //If no zipcode is provided
            if (Search == 0)
            {
                string noSearch = "Please provide Zipcode";
            }
            //Business Owners data from the API
            String businessOwnerjsonString = GetData("https://data.cityofchicago.org/resource/r5kz-chrr.json");
            businessOwners = BusinessOwnerDetails.BusinessOwner.FromJson(businessOwnerjsonString);
            ViewData["businessOwners"] = businessOwners;

            //Grocery stores data from te API
            String firejsonString = GetData("https://data.cityofchicago.org/resource/53t8-wyrc.json");
            groceryStores = GroceryStore.FromJson(firejsonString);
            ViewData["groceryStores"] = groceryStores;

            //Filtering Business Owners and Grocery stores from the zip search
            businessOwners = businessOwners.Where(x => x.ZipCode == Search).ToArray();
            groceryStores = groceryStores.Where(x => x.ZipCode == Search).ToArray();
            SearchCompleted = true;
        }

        //This generic method is used to get the JsonString by calling an API
        public string GetData(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString(url);
                return jsonString;
            }
        }
    }
}