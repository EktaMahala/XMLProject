using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace GroceryStores.Pages
{
    public class FellowGroupsAPIServiceModel : PageModel
    {
        public ICollection<MobileFoodSchedules.MobileFoodSchedule> mobileFoodSchedules { get; set; }
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                String foodSchedulesJson = webClient.DownloadString("https://mobilefoodschedules.azurewebsites.net/api/saapprovedfoodschedules");
                mobileFoodSchedules = MobileFoodSchedules.MobileFoodSchedule.FromJson(foodSchedulesJson);



                ViewData["MobileFoodSchedules"] = mobileFoodSchedules;
            }
        }
    }
}