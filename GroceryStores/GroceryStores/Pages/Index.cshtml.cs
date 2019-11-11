using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessOwnerDetails;
using Microsoft.Extensions.Logging;

namespace GroceryStores.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                string BusinessOwnerJsonString = webClient.DownloadString("https://data.cityofchicago.org/resource/ezma-pppn.json");
                BusinessOwner[] allBusinessOwners = BusinessOwner.FromJson(BusinessOwnerJsonString);
                ViewData["allBusinessOwners"] = allBusinessOwners;

                string GroceryStoreJsonString = webClient.DownloadString("https://data.cityofchicago.org/resource/53t8-wyrc.json");
                GroceryStore[] allGroceryStores = GroceryStore.FromJson(GroceryStoreJsonString);
                ViewData["allGroceryStores"] = allGroceryStores;

                IDictionary<string, GroceryStore> groceryStores = new Dictionary<string, GroceryStore>();

                List<BusinessOwner> groceryStoresOwners = new List<BusinessOwner>();

                foreach (GroceryStore groceryStore in allGroceryStores)
                {
                    groceryStores.Add(groceryStore.StoreName, groceryStore);
                }

                foreach (BusinessOwner businessOwner in allBusinessOwners)
                {
                    foreach (var groceryStore in groceryStores)
                    {
                        if (groceryStore.Value.LicenseId == businessOwner.LicenseId)
                        {
                            groceryStoresOwners.Add(businessOwner);
                        }
                    }
                }
                ViewData["groceryStoresOwners"] = groceryStoresOwners;
            }
        }
    }
}
