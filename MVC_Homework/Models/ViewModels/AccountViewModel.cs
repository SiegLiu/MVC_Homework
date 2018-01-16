using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models.ViewModels
{
    public class AccountViewModel
    {
        public string category { get; set; }
        public DateTime billdate { get; set; }
        public int amount { get; set; }
    }
}