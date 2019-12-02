using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryStores.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using BusinessOwnerDetails;
using System.Net;

namespace GroceryStores.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryStoreSurveysController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public GroceryStoreSurveysController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // GET: api/GroceryStoreSurveys
        [HttpGet]
        public ActionResult<IEnumerable<BusinessOwner>> GetGroceryStoreSurvey()
        {
            using (WebClient webClient = new WebClient())
            {
                string businessOwnerEndPoint = "https://data.cityofchicago.org/resource/r5kz-chrr.json";
                string BusinessOwnerJsonString = webClient.DownloadString(businessOwnerEndPoint);
                BusinessOwner[] allBusinessOwners = BusinessOwner.FromJson(BusinessOwnerJsonString);
                
                string groceryStoreEndPoint = "https://data.cityofchicago.org/resource/53t8-wyrc.json";
                string GroceryStoreJsonString = webClient.DownloadString(groceryStoreEndPoint);
                GroceryStore[] allGroceryStores = GroceryStore.FromJson(GroceryStoreJsonString);
                
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


                return businessOwnerList;
            }
        }
    }
}
