
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
    public class GroceryBusinessOwnersModel : PageModel
    {
        private readonly ILogger<GroceryBusinessOwnersModel> _logger;

        public GroceryBusinessOwnersModel(ILogger<GroceryBusinessOwnersModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                string businessOwnerEndPoint = "https://data.cityofchicago.org/resource/r5kz-chrr.json";
                string BusinessOwnerJsonString = webClient.DownloadString(businessOwnerEndPoint);
                BusinessOwner[] allBusinessOwners = BusinessOwner.FromJson(BusinessOwnerJsonString);
                ViewData["allBusinessOwners"] = allBusinessOwners;

                string groceryStoreEndPoint = "https://data.cityofchicago.org/resource/53t8-wyrc.json";
                string GroceryStoreJsonString = webClient.DownloadString(groceryStoreEndPoint);
                GroceryStore[] allGroceryStores = GroceryStore.FromJson(GroceryStoreJsonString);
                ViewData["allGroceryStores"] = allGroceryStores;

                IDictionary<long, GroceryStore> groceryStoresMap = new Dictionary<long, GroceryStore>();
                List<BusinessOwner> businessOwnerList = new List<BusinessOwner>();

                foreach (GroceryStore grocery in allGroceryStores)
                {
                    if (!groceryStoresMap.ContainsKey(grocery.ZipCode))
                    {
                        groceryStoresMap.Add(grocery.ZipCode, grocery);
                    }
                }


                foreach (BusinessOwner businessRec in allBusinessOwners)
                {
                    if (groceryStoresMap.ContainsKey(businessRec.ZipCode))
                    {
                        businessOwnerList.Add(businessRec);
                    }
                }

                ViewData["businessOwners"] = businessOwnerList;
            }
        }
    }
}
