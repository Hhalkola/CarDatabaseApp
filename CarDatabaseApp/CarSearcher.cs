using System;
using System.Collections.Generic;
using System.Text;

namespace CarDatabaseApp
{
    class CarSearcher
    {
        public static void CarSearchMenu()
        {
            Console.WriteLine("Which search criteria you want to use?");
            Console.WriteLine("1 - Brand");
            Console.WriteLine("2 - Brand & model");
            Console.WriteLine("3 - Price");
            Console.WriteLine("4 - Fuel type");
            Console.WriteLine("5 - All cars");
            Console.WriteLine("6 - Quit");
            int searchCriteria = int.Parse(Console.ReadLine());

            switch (searchCriteria)
            {
                case 1:
                    SqlQuery.Connection();
                    SqlQuery.SearchByCarBrand();
                    break;
                case 2:
                    SqlQuery.Connection();
                    SqlQuery.SearchByBrandAndModel();
                    break;
                case 3:
                    SqlQuery.Connection();
                    SqlQuery.SearchCarByPrice();
                    break;
                case 4:
                    SqlQuery.Connection();
                    SqlQuery.SearchCarByFuelType();
                    break;
                case 5:
                    SqlQuery.Connection();
                    SqlQuery.GetAllCarsFromDb();
                    break;
                case 6:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
