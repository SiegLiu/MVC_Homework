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
            _dao.Insert(accountbook);
        }

        public void Edit (AccountViewModel accountbook)
        {
            _dao.Update(accountbook);
        }

        public void Delete(AccountViewModel accountbook)
        {
            _dao.Delete(accountbook);
        }

        public AccountViewModel GetSingle(Guid Id)
        {
            return _dao.GetSingle(Id);
        }

        public IEnumerable<AccountViewModel> GetAllAccount()
        {
            return _dao.GetAllAccount();
        }

        public IEnumerable<AccountViewModel> GetAllAccount(int? page)
        {
            return _dao.GetAllAccount(page);
        }
    }
}