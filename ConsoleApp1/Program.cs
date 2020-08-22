using Dapper;
using NetCoreBaseDemo.DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TheAcme.EntityModule.DbModels;

namespace ConsoleApp1
{
    class Program
    {

        public abstract class SalesDb : IDisposable
        {
            protected static IDbConnection OpenConnection()
            {
                IDbConnection connection = new SqlConnection("Server=.;Database=NetCore;User ID=sa;Password=123;");
                connection.Open();
                return connection;
            }

            public void Dispose()
            {
                OpenConnection().Dispose();
            }
        }

        public class LeadService : SalesDb
        {
          
        }
        static void Main(string[] args)
        {
            try
            {
                LeadService service = new LeadService();


                using (IDbConnection connection = new SqlConnection("Server=.;Database=MasterDb;User ID=sa;Password=123;"))
                {
                    connection.Open();
                   var multi= connection.QueryMultiple("select * from SysAccounts;select COUNT(*) from SysAccounts");
                   var accounts= multi.Read<SysAccount>(false).ToList();
                    var account2s = multi.Read<int>().First();
                };



            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
