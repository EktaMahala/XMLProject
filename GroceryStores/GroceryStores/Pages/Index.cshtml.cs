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
                string businessOwnerEndPoint = "https://data.cityofchicago.org/resource/ezma-pppn.json";
                string BusinessOwnerJsonString = webClient.DownloadString(businessOwnerEndPoint);
                BusinessOwner[] allBusinessOwners = BusinessOwner.FromJson(BusinessOwnerJsonString);
                ViewData["allBusinessOwners"] = allBusinessOwners;

                string groceryStoreEndPoint = "https://data.cityofchicago.org/resource/53t8-wyrc.json";
                string GroceryStoreJsonString = webClient.DownloadString(groceryStoreEndPoint);
                GroceryStore[] allGroceryStores = GroceryStore.FromJson(GroceryStoreJsonString);
                ViewData["allGroceryStores"] = allGroceryStores;

                //IDictionary<string, GroceryStore> groceryStores = new Dictionary<string, GroceryStore>();

                List<BusinessOwner> groceryStoresOwners = new List<BusinessOwner>();

            

                foreach (BusinessOwner businessOwner in allBusinessOwners)
                {
                    foreach (var groceryStore in allGroceryStores)
                    {
                        if (groceryStore.AccountNumber == businessOwner.AccountNumber)
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
