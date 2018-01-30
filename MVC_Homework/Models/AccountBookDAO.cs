using Dapper;
using MVC_Homework.Models.ViewModels;
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
            const string sql = "SELECT Category, Amount, Billdate, Remark FROM AccountBook ORDER BY Billdate DESC";
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                result = conn.Query<AccountViewModel>(sql).ToList();
            }
            return result;
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
    }
}