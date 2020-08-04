using Dapper;
using NetCoreBaseDemo.DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
            public IEnumerable<SysAccount> Select()
            {
                using (IDbConnection connection = OpenConnection())
                {
                   
                    return connection.Query<SysAccount>("select * from SysAccount");
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                LeadService service = new LeadService();
                Enumerable.Range(0, 10000).AsParallel().ForAll(item=> {
                   Console.WriteLine($"{item}--"+service.Select().FirstOrDefault().Id);

                });
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
