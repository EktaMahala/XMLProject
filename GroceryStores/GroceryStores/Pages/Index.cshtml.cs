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

        [BindProperty]
        public string LicenseID { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
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

                /*IDictionary<long, BusinessOwner> businessOwnersMap = new Dictionary<long, BusinessOwner>();

                List<GroceryStore> groceryStoresOwners = new List<GroceryStore>();

                foreach(BusinessOwner businessOwner in allBusinessOwners){
                    businessOwnersMap.Add(businessOwner.LicenseId, businessOwner);
                }


                foreach (GroceryStore groceryStore in allGroceryStores)
                {
                    if (businessOwnersMap.ContainsKey(groceryStore.LicenseId))
                    {
                        groceryStoresOwners.Add(groceryStore);
                    }
                }*/


                //foreach (BusinessOwner businessOwner in allBusinessOwners)
                //{
                //    foreach (var groceryStore in allGroceryStores)
                //    {
                //        if (groceryStore.LicenseId == businessOwner.LicenseId)
                //        {
                //            groceryStoresOwners.AddRange(groceryStore.LicenseId, groceryStore);
                //        }
                //    }
                //}
                ViewData["businessOwners"] = businessOwnerList;
            }
        }
    }
}
