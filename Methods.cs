using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace A2SharonPatel
{
    class Methods
    {
        static string GetConnectionString(string NorthwindLocalDB)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("config.json");
            IConfiguration config = configurationBuilder.Build();

            return config["ConnectionStrings:" + NorthwindLocalDB];
        }
        public static void printProducts()
        {
            string cs = GetConnectionString("NorthwindLocalDB");
            SqlConnection conn = new SqlConnection(cs);


            string query = "select p.ProductID, p.ProductName, c.CategoryName, s.CompanyName from Products p " +
                "inner join Categories c on p.CategoryID = c.CategoryID " +
                "inner join Suppliers s on p.SupplierID = s.SupplierID";
            
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("==================================================================================================================\n");
            Console.WriteLine("Products:");
            Console.WriteLine("ProductID "+"  " +  "ProductName "+ "\t\t\t" + "CategoryName" + " \t" + "CompanyName");
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string productName = reader.GetString(1);
                string categoryName = reader.GetString(2);
                string companyName = reader.GetString(3);

                Console.WriteLine($"{id,7} {productName,-40} {categoryName,-15} {companyName,-40}");
            }
            conn.Close();
        }

        public static void printCategory()
        {
            string cs = GetConnectionString("NorthwindLocalDB");
            SqlConnection conn = new SqlConnection(cs);

            string query = "select CategoryID, CategoryName from Categories";
               

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("==================================================================================================================\n\n");
            Console.WriteLine("Categories:");
            Console.WriteLine("CategoryID " + "  " + "CategoryName ");
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string categoryName = reader.GetString(1);
                Console.WriteLine($"{id,10} {categoryName,-40}");
            }
            conn.Close();
        }

        public static void printSuppliers()
        {
            string cs = GetConnectionString("NorthwindLocalDB");
            SqlConnection conn = new SqlConnection(cs);

            string query = "select SupplierID, CompanyName from Suppliers";


            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("==================================================================================================================\n\n");
            Console.WriteLine("Suppliers:");
            Console.WriteLine("SupplierID " + "  " + "CompanyName ");
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string companyName = reader.GetString(1);

                //string format = string.Format("{0,7}{1,-40}", id, companyName);
                Console.WriteLine($"{id,10} {companyName,-40}");
               // Console.WriteLine(format);

            }
            conn.Close();
        }

        public static void printProductByCategoryId()
        {
            Console.WriteLine("Enter CategoryID");
            int input = Convert.ToInt32(Console.ReadLine());

            string cs = GetConnectionString("NorthwindLocalDB");
            SqlConnection conn = new SqlConnection(cs);

           string query = "select p.ProductID, p.ProductName, c.CategoryName, s.CompanyName from Products p " +
                "inner join Categories c on p.CategoryID = c.CategoryID " +
                "inner join Suppliers s on p.SupplierID = s.SupplierID where p.CategoryID = @CategoryID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("CategoryID", input);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("==================================================================================================================\n");
            Console.WriteLine("Products by Category ID:");
            Console.WriteLine("ProductID " + "  " + "ProductName " + "\t\t\t" + "CategoryName" + " \t" + "CompanyName");
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string productName = reader.GetString(1);
                string categoryName = reader.GetString(2);
                string companyName = reader.GetString(3);

                Console.WriteLine($"{id,10} {productName,-40} {categoryName,-15} {companyName,-40}");
            }
            conn.Close();
        }

        public static void printProductBySupplierId()
        {
            Console.WriteLine("Enter SupplierID");
            int input = Convert.ToInt32(Console.ReadLine());

            string cs = GetConnectionString("NorthwindLocalDB");
            SqlConnection conn = new SqlConnection(cs);

            string query = "select p.ProductID, p.ProductName, c.CategoryName, s.CompanyName from Products p " +
                 "inner join Categories c on p.CategoryID = c.CategoryID " +
                 "inner join Suppliers s on p.SupplierID = s.SupplierID where p.SupplierID = @SupplierID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("SupplierID", input);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("==================================================================================================================\n\n");
            Console.WriteLine("Products by Supplier ID:");
            Console.WriteLine("ProductID " + "  " + "ProductName " + "\t\t\t\t" + "CategoryName" + " \t\t" + "CompanyName");
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string productName = reader.GetString(1);
                string categoryName = reader.GetString(2);
                string companyName = reader.GetString(3);

                Console.WriteLine($"{id,10} {productName,-40} {categoryName,-15} {companyName,-40}");
            }
            conn.Close();
        }
    }
}
