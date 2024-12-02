using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Diagnostics;

using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Manager
{
     public class DataAccess
    {
        public int AddCategory(string connectionString)
        {
            string CategoryName;
            int rowAffected = 0;
            string toContinue = "y";
            while (toContinue == "y")
            {
                Console.WriteLine("insert catagory name");
                CategoryName = Console.ReadLine();
                Console.WriteLine("Continue?");
                toContinue = Console.ReadLine();
                string query = "INSERt INTO Category (CategoryName)" + "VALUES(@CategoryName)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value = CategoryName;
                    connection.Open();
                    rowAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
            return rowAffected;
        }
        public int AddProuduct(string connectionString)
        {
            int rowAffected = 0;
            string toContinue = "y";
            while (toContinue == "y")
            {
                string ProductName, ProductDecripition, Price, ImgPath, Category_ID;
                Console.WriteLine("insert Category_ID name");
                Category_ID = Console.ReadLine();
                Console.WriteLine("insert ProductName name");
                ProductName = Console.ReadLine();
                Console.WriteLine("insert ProductDecripition name");
                ProductDecripition = Console.ReadLine();

                Console.WriteLine("insert Price name");
                Price = Console.ReadLine();
                Console.WriteLine("insert ImgPath name");
                ImgPath = Console.ReadLine();
                Console.WriteLine("Continue?");
                toContinue = Console.ReadLine();
                string query = "INSERt INTO Products (Category_ID,ProductName,ProductDecripition,Price,ImgPath)" + "VALUES(@Category_ID,@ProductName,@ProductDecripition,@Price,@ImgPath)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Category_ID", System.Data.SqlDbType.VarChar, 10).Value = Category_ID;
                    cmd.Parameters.Add("@ProductName", System.Data.SqlDbType.VarChar, 10).Value = ProductName;
                    cmd.Parameters.Add("@ProductDecripition", System.Data.SqlDbType.VarChar, 10).Value = ProductDecripition;
                    cmd.Parameters.Add("@Price", System.Data.SqlDbType.VarChar, 10).Value = Price;
                    cmd.Parameters.Add("@ImgPath", System.Data.SqlDbType.VarChar, 10).Value = ImgPath;
                    connection.Open();
                    rowAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
            return rowAffected;


        }


        public void getAllProduct(string connectionString)
        {
            string query = "select * from Product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                    try
                {
                    connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                Console.ReadLine();


            }

        }
        public void getAllCategory(string connectionString)
        {
            string query = "select * from Product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                Console.ReadLine();


            }

        }

    }
}
