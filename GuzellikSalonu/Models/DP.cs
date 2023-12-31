using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace GuzellikSalonu.Models
{
    public class DP
    {
        public static string connectionString = @"Server=AHMET\SQLKODLAB ;Database=GuzellikSalonu;Integrated Security=true;";
        //Ekle güncelle sil arama aldığı parametre değerlerini proc gönderen bir metot
        public static void ExecuteReturn(string procadi, DynamicParameters degisken = null)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                db.Execute(procadi, degisken, commandType: CommandType.StoredProcedure);
            }
        }

        public static IEnumerable<T> Listeleme<T>(string procadi, DynamicParameters degisken = null)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                return db.Query<T>(procadi, degisken, commandType: CommandType.StoredProcedure);
            }
        }
    }
}