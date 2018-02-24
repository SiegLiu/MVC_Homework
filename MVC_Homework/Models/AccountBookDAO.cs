using Dapper;
using MVC_Homework.Models.ViewModels;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVC_Homework.Models
{
    public class AccountBookDAO
    {
        private string ConnectionString { get; set; }

        public AccountBookDAO()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["HomeworkDB"].ConnectionString;
        }

        public List<AccountViewModel> GetAllAccount()
        {   
            var result = new List<AccountViewModel>();
            const string sql = "SELECT Id, Category, Amount, Billdate, Remark FROM AccountBook ORDER BY Billdate DESC";
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                result = conn.Query<AccountViewModel>(sql).ToList();
            }
            return result;
        }

        public IPagedList<AccountViewModel> GetAllAccount(int? page)
        {
            //var pageNumber = page ?? 1;
            var pageIndex = page.HasValue ? page.Value < 1 ? 1 : page.Value : 1;

            var result = new List<AccountViewModel>();
            const string sql = "SELECT Id, Category, Amount, Billdate, Remark FROM AccountBook ORDER BY Billdate DESC";
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                result = conn.Query<AccountViewModel>(sql).ToList();
            }
            return result.ToPagedList(pageIndex, 10);
        }

        public int Insert(AccountViewModel AccountBook)
        {
            const string sql = @"INSERT INTO AccountBook(Id, Category, Amount, Billdate, Remark) 
                                 Values (NEWID(), @category, @amount, @billdate, @remark)";
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    return conn.Execute(sql, new
                    {
                        category = AccountBook.Category,
                        amount = AccountBook.Amount,
                        billdate = AccountBook.Billdate,
                        remark = AccountBook.Remark
                    });
                }
                catch (Exception)
                {
                    //TODO 增加LOG
                    throw;
                }
            }
        }
        public int Update(AccountViewModel AccountBook)
        {
            const string sql = @"UPDATE AccountBook SET Category=@category, Amount=@amount, Billdate=@billdate, remark=@remark WHERE Id=@id";
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    return conn.Execute(sql, new
                    {
                        id = AccountBook.Id,
                        category = AccountBook.Category,
                        amount = AccountBook.Amount,
                        billdate = AccountBook.Billdate,
                        remark = AccountBook.Remark
                    });
                }
                catch (Exception)
                {
                    //TODO 增加LOG
                    throw;
                }
            }
        }

        public int Delete(AccountViewModel AccountBook)
        {
            const string sql = @"DELETE FROM AccountBook WHERE Id=@id";
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    return conn.Execute(sql, new
                    {
                        id = AccountBook.Id
                    });
                }
                catch (Exception)
                {
                    //TODO 增加LOG
                    throw;
                }
            }
        }

        public AccountViewModel GetSingle(Guid Id)
        {
            const string sql = @"SELECT * FROM AccountBook WHERE Id=@id";
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    var result = conn.Query<AccountViewModel>(sql, new
                    {
                        id = Id
                    }).FirstOrDefault();
                    return result;
                }
                catch (Exception)
                {
                    //TODO 增加LOG
                    throw;
                }
            }
        }
    }
}