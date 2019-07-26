using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JayGervais_CPRG215_MVC_Lab3.Models
{
    public class ProductDB
    {
        public static List<Product> GetProducts()
        {
            List<Product> productsList = new List<Product>();
            string getProdQuery = @"SELECT ProductID, Name, ShortDescription, CategoryID, UnitPrice, OnHand " +
                                   "FROM Products";

            using (SqlConnection con = HalloweenDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(getProdQuery, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Product products;
                    while (reader.Read())
                    {
                        products = new Product();
                        products.ProductID = reader["ProductID"].ToString();
                        products.Name = reader["Name"].ToString();
                        products.ShortDescription = reader["ShortDescription"].ToString();
                        products.CategoryID = reader["CategoryID"].ToString();
                        products.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                        products.OnHand = Convert.ToInt32(reader["OnHand"]);
                        productsList.Add(products);
                    }
                    con.Close();
                }
            }
            return productsList;   
        }

        public static Product ProductDetails(string productID)
        {
            Product details = null;
            string productDetailsQuery = @"SELECT ProductID, Name, ShortDescription, LongDescription, CategoryID, ImageFile, UnitPrice, OnHand " +
                                          "FROM Products WHERE ProductID = @ProductID";

            using (SqlConnection con = HalloweenDB.GetConnection())
            {
                using(SqlCommand cmd = new SqlCommand(productDetailsQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        details = new Product();
                        details.ProductID = reader["ProductID"].ToString();
                        details.Name = reader["Name"].ToString();
                        details.ShortDescription = reader["ShortDescription"].ToString();
                        details.LongDescription = reader["LongDescription"].ToString();
                        details.CategoryID = reader["CategoryID"].ToString();
                        details.ImageFile = reader["ImageFile"].ToString();
                        details.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                        details.OnHand = Convert.ToInt32(reader["OnHand"]);
                    }
                    con.Close();
                }
            }
            return details;
        }

    }
}