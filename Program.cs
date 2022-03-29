using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADONET_1
{
    class Program
    {
        static void Main(string[] args)
        {
           // string sqlStringConnection = "Data Source = localhost,1433;Initial Catalog=xtlab;User ID = sa; PWD=Password123";

       var SqlstringBuilder = new SqlConnectionStringBuilder();
      SqlstringBuilder["Server"] = "localhost,1433";
      SqlstringBuilder["Database"] = "xtlab";
      SqlstringBuilder["UID"] = "sa";
     SqlstringBuilder["PWD"] = "Password123";

    string sqlStringConnection = SqlstringBuilder.ToString();


             using var connection = new SqlConnection(sqlStringConnection);
            System.Console.WriteLine(connection.State);

            connection.Open();
            DbCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP () * FROM sanpham";
            var datareader = command.ExecuteReader();
            System.Console.WriteLine("My Product : ");
            while  (datareader.Read())
            {
             System.Console.WriteLine($"{ datareader["TenSanPham"],10}");
            } 
            //.. Query

            connection.Close();

            
          
        }
    }
}
