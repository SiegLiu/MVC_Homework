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
            const string sql = "SELECT Categoryyy AS category, Dateee AS billdate, Amounttt AS amount FROM AccountBook";
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                result = conn.Query<AccountViewModel>(sql).ToList();
            }
            return result;
        }
    }
}