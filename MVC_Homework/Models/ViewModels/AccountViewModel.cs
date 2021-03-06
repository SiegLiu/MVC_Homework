﻿using MVC_Homework.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Models.ViewModels
{
    public class AccountViewModel
    {
        public System.Guid Id { get; set; }

        [Required]
        [Display(Name = "類別")]
        public string Category { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "金額（元）")]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [RemotePlus("ValidateDateLessOrEqual", "Valid", "", ErrorMessage = "「{0}」不得大於今天")]
        [Display(Name = "日期")]
        public DateTime Billdate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "「{0}」最多輸入{1}個字元。", MinimumLength = 1)]
        [Display(Name = "備註")]
        public string Remark { get; set; }
    }
}