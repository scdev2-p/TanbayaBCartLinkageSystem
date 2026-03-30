using System;
using System.Data.SqlClient;

namespace Create_user
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // db接続情報
            string connectionString = "Data Source=TKYSVTNB0509;Initial Catalog=master;User ID=TanbayaSqlAdmin; Password=1SQad69Lmi0n";
            try
            {
                // 3 SqlConnectionのインスタンスを作成
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // 4 接続
                    connection.Open();
                    Console.WriteLine("接続成功。");

                    // Query
                    string sqlQuery = "USE [tempdb]  " +
                        "if not exists(  SELECT * " +
                                        "FROM sys.database_principals " +
                                        "WHERE name = 'tnb')  " +
                        "begin CREATE USER[tnb] FOR LOGIN[tnb]" +
                        " ALTER ROLE[db_owner] ADD MEMBER[tnb] end";


                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        Console.WriteLine(reader);
                        reader.Close();
                    }

                    sqlQuery = "USE [tempdb]  " +
                        "if not exists(  SELECT * " +
                                        "FROM sys.database_principals " +
                                        "WHERE name = 'ds1')  " +
                        "begin CREATE USER[ds1] FOR LOGIN[ds1]" +
                        " ALTER ROLE[db_owner] ADD MEMBER[ds1] end";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        Console.WriteLine(reader);
                        reader.Close();
                    }

                    sqlQuery = "USE [tempdb]  " +
                        "if not exists(  SELECT * " +
                                        "FROM sys.database_principals " +
                                        "WHERE name = 'tnbr')  " +
                        "begin CREATE USER[tnbr] FOR LOGIN[tnbr]" +
                        " ALTER ROLE[db_owner] ADD MEMBER[tnbr] end";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        Console.WriteLine(reader);
                        reader.Close();
                    }

                    connection.Close();
                }
            }
            // 接続失敗の処理
            catch (SqlException e)
            {
                Console.WriteLine("接続エラー: " + e.Message);
            }
            // 処理が終わってもすぐにコンソールが閉じないように 
            //Console.ReadKey(true);
        }
    }
}
