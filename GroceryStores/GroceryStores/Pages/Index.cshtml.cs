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
            //Business Owners data from the API
            string BusinessOwnerJsonString = GetData("https://data.cityofchicago.org/resource/r5kz-chrr.json");
            BusinessOwner[] allBusinessOwners = BusinessOwner.FromJson(BusinessOwnerJsonString);
            ViewData["allBusinessOwners"] = allBusinessOwners;

            //Grocery stores data from te API
            string GroceryStoreJsonString = GetData("https://data.cityofchicago.org/resource/53t8-wyrc.json");
            GroceryStore[] allGroceryStores = GroceryStore.FromJson(GroceryStoreJsonString);
            ViewData["allGroceryStores"] = allGroceryStores;

            //Map to store the the zipcode as key and grocery store as Value
            IDictionary<long, GroceryStore> groceryStoresMap = new Dictionary<long, GroceryStore>();

            //List to store filtered business owners
            List<BusinessOwner> businessOwnerList = new List<BusinessOwner>();


            //Iterating through Grocery stores and adding them to the groceryStoresMap
            foreach (GroceryStore grocery in allGroceryStores)
            {
                if (!groceryStoresMap.ContainsKey(grocery.ZipCode))
                {
                    groceryStoresMap.Add(grocery.ZipCode, grocery);
                }
            }

            //Filtering the Business Owners and adding thefiltered records to businessOwnerList
            foreach (BusinessOwner businessRec in allBusinessOwners)
            {
                if (groceryStoresMap.ContainsKey(businessRec.ZipCode))
                {
                    businessOwnerList.Add(businessRec);
                }
            }
            ViewData["businessOwners"] = businessOwnerList;
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
