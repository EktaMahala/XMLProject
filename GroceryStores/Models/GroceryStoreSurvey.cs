using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStores.Models
{
    public class GroceryStoreSurvey
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Mobile")]
        public string mobile { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Zip")]
        public string zip { get; set; }
        [Display(Name = "Most Preferred Grocery Stores to shop")]
        public string stores { get; set; }
        

    }
}