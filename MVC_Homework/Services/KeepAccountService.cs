using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Homework.Models;
using MVC_Homework.Models.ViewModels;

namespace MVC_Homework.Services
{
    public class KeepAccountService
    {
        private readonly AccountBookDAO _dao;
        public KeepAccountService()
        {
            _dao = new AccountBookDAO();
        }

        public void Add (AccountViewModel accountbook)
        {
            accountbook.billdate = DateTime.Now;
            _dao.Insert(accountbook);
        }

        public IEnumerable<AccountViewModel> GetAllAccount()
        {
            return _dao.GetAllAccount();
        }
    }
}