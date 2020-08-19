using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;

namespace A2SharonPatel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nAssignment by Sharon Patel\n\n");
            //Console.WriteLine(cs);
            //printCustomers();

            bool check = false; //used for do While Condition
            var choice1 = 0;  //Taking choice for Main Menu
            do
            {
                try
                {
                    //Main Menu
                    Console.WriteLine("==================================================================================================================\n\n");
                    Console.WriteLine("Welcome Please Choose a Command");
                    Console.WriteLine("Press 1 to Get All Products");
                    Console.WriteLine("Press 2 to Get All Categories");
                    Console.WriteLine("Press 3 to Get All Suppliers");
                    Console.WriteLine("Press 4 to Get Products by Category ID");
                    Console.WriteLine("Press 5 to Get Products by Supplier ID");
                    Console.WriteLine("Press 6 to Exit");

                    choice1 = Convert.ToInt32(Console.ReadLine());

                    switch (choice1)
                    {

                        case 1:
                            Methods.printProducts();
                            break;
                        case 2:
                            Methods.printCategory();
                            break;
                        case 3:
                            Methods.printSuppliers();
                            break;
                        case 4:
                            Methods.printProductByCategoryId();
                            break;
                        case 5:
                            Methods.printProductBySupplierId();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Selection is in Valid! Please Enter number Between 1 to 5");
                            break;

                    }//END OF SWITCH CASE



                }//END OF TRY BLOCK
                catch (FormatException)
                {
                    Console.WriteLine("InValid Input! Please Enter correct Data to processed");
                }//END OF CATCH BLOCK
            } while (!check); //END OF DO WHILE LOOP
        }//END OF MAIN METHOD
    }//END OF CLASS PROGRAM
}//END OF PROJECT
