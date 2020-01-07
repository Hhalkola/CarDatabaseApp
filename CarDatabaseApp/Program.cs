using System;
using System.Collections.Generic;

namespace CarDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary for cars, use plate number as key
            //Values are the other parameters of the car
            Dictionary<string, string> carsDictionary = new Dictionary<string, string>();

            //Main menu
            Console.WriteLine("What do you want to do?" );
            Console.WriteLine("1 - Add car");
            Console.WriteLine("2 - Search car");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                //Add Car
                case 1:
                    string platenumber = CarAdder.CarPlateNumber();
                    string carbrand = CarAdder.CarBrand();
                    string carmodel = CarAdder.CarModel();
                    int caryear = CarAdder.CarYear();
                    int fueltype = CarAdder.FuelType();
                    double price = CarAdder.CarPrice();
                    string color = CarAdder.CarColor();

                    if (carsDictionary.ContainsKey(platenumber))
                    {
                        Console.WriteLine("Car with specific plate number already exists");
                    }
                    else
                    {
                        carsDictionary.Add(platenumber, carbrand + " " + carmodel + " " + caryear + " " + fueltype + " " + price + " " + color);
                    }
                    break;
                //Search Car
                case 2:
                    break;

                //Delete Car
                case 3:
                    break;
            }
        }
    }
}
