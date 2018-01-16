using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models.ViewModels
{
    public class AccountViewModel
    {
        [Display(Name = "類別")]
        public string category { get; set; }

        [Display(Name = "日期")]
        public DateTime billdate { get; set; }

        [Display(Name = "金額（元）")]
        public int amount { get; set; }
    }
}