using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentaEntityFrameWork.Models;

namespace TentaEntityFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //OrdersPerEmployee(); //fråga 4
           // CustomersWithNamesLongerThan25Characters(); //Fråga5//
        }

        private static void CustomersWithNamesLongerThan25Characters()
        {
            using (NorthWindEntityContext cx = new NorthWindEntityContext())
            {

                var names = from n in cx.Customers
                            where n.CompanyName.Length > 25
                            select n.CompanyName;
                foreach (var name in names) 
                {
                    Console.WriteLine(name);
                }

                Console.ReadLine();
            }
        }

        private static void OrdersPerEmployee()
        {
            using (NorthWindEntityContext cx = new NorthWindEntityContext())
            {
                foreach (var data in cx.Employees)
                {

                }
           
            }
        }
    }
}
