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
            int searchCriteria = int.Parse(Console.ReadLine());

            switch (searchCriteria)
            {
                case 1:
                    SqlQuery.SearchByCarBrand();
                    break;
                case 2:

                    break;
            }
        }
    }
}
