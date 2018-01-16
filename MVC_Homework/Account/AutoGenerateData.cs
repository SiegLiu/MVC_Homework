﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Homework.Models.ViewModels;

namespace MVC_Homework.Account
{
    public class AutoGenerateData
    {
        public List<AccountViewModel> GenerateData()
        {
            List<AccountViewModel> listFakeData = new List<AccountViewModel>();
            Random rand = new Random();
            decimal u1, u2;
            decimal mean = 2000;
            decimal stdDev = 2000;
            for (int i = 0; i <= 100; i++)
            {
                u1 = (decimal)(1.0 - rand.NextDouble());
                u2 = (decimal)(1.0 - rand.NextDouble());
                decimal randStdNormal = (decimal)(Math.Sqrt(-2.0 * Math.Log((double)u1)) * Math.Sin(2.0 * Math.PI * (double)u2));
                decimal randNormal = mean + stdDev * randStdNormal;
                int amount = Math.Abs((int)randNormal);
                //string strAmount = amount.ToString("#,0");
                AccountViewModel fakeData = new AccountViewModel
                {
                    category = (randNormal < 0) ? "支出" : "收入",
                    billdate = DateTime.Now.Date.AddDays(-i),
                    amount = amount
                };
                listFakeData.Add(fakeData);
            }
            return listFakeData;
        }
    }
}