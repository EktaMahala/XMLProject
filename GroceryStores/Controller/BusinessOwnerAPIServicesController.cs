using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryStores.Models;
using System.Net;
using BusinessOwnerDetails;

namespace GroceryStores.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessOwnerAPIServicesController : ControllerBase
    {
        private readonly GroceryStoresContext _context;

        public BusinessOwnerAPIServicesController(GroceryStoresContext context)
        {
            _context = context;
        }

        // GET: api/BusinessOwnerAPIServices
        [HttpGet]
        public IList<BusinessOwnerAPIService> GetBusinessOwnerAPIService()
        {
            IList<BusinessOwnerAPIService> outputList = new List<BusinessOwnerAPIService>();
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
                        BusinessOwnerAPIService bussOwner = new BusinessOwnerAPIService();
                        bussOwner.LicenseId = businessRec.LicenseId;
                        bussOwner.LicenseDescription = businessRec.LicenseDescription;
                        bussOwner.BusinessActivity = businessRec.BusinessActivity;
                        bussOwner.LegalName = businessRec.LegalName;
                        bussOwner.LicenseStatus = businessRec.LicenseStatus;
                        bussOwner.ZipCode = businessRec.ZipCode;
                        outputList.Add(bussOwner);
                    }
                }                
            }
            return outputList;
        }       
    }
}
