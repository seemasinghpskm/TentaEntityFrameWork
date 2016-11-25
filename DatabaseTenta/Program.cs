using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTenta
{
    class Program
    {  
        static void Main(string[] args)
        {
            // ProductsByCategoryName("Confections"); //Fråga 1
            // SalesByTerritory();  //Fråga 2
            EmployeesPerRegion();  //Fråga3

        }

        private static void EmployeesPerRegion()
        {

            string cns = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cns))
            {

                string sqlCommand = @"SELECT        Region.RegionDescription, COUNT(*) AS TotalEmployees
FROM            Employees INNER JOIN
                         EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN
                         Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID INNER JOIN
                         Region ON Territories.RegionID = Region.RegionID
GROUP BY Region.RegionDescription";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Console.WriteLine("{0},{1}", rd.GetString(0),rd.GetInt32(1));
                }
                Console.ReadLine();
            }
        }


        private static void SalesByTerritory()
        {
            string cns = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cns))
            {

                string sqlCommand = @"SELECT top 5  Territories.TerritoryDescription,SUM((1- [Order Details].Discount)*( [Order Details].UnitPrice*[Order Details].Quantity)) as TotalSales
                        FROM            Employees INNER JOIN
                         EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN
                         Orders ON Employees.EmployeeID = Orders.EmployeeID INNER JOIN
                         [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN
                         Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID
						 Group by Territories.TerritoryDescription
						 order by TotalSales desc";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Console.WriteLine("{0},{1}", rd.GetString(0),rd.GetDouble(1));
                }
                Console.ReadLine();
            }
        }

        private static void ProductsByCategoryName(string category)
        {
            
                string cns = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection con = new SqlConnection(cns))
            {

                string sqlCommand = @"SELECT Products.ProductName, Products.UnitPrice,
                       Products.UnitsInStock FROM Products INNER JOIN
                        Categories ON Products.CategoryID = Categories.CategoryID
                    WHERE(Categories.CategoryName =@CategoryName)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand,con);
                cmd.Parameters.AddWithValue("@CategoryName", category);
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    Console.WriteLine("{0},{1},{2}", rd.GetString(0), rd.GetDecimal(1),rd.GetInt16(2));
                }
                Console.ReadLine();
            }
        }
    }
}
