using System;
using System.Collections.Generic;

namespace CarDatabaseApp
{
    class Program
    {
        static void Main()
        {
            //Dictionary for cars, use plate number as key
            //Values are the other parameters of the car
            Dictionary<string, string> carsDictionary = new Dictionary<string, string>();

            //Main menu
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Add car");
            Console.WriteLine("2 - Search car");
            Console.WriteLine("3 - Delete car");
            Console.WriteLine("4 - Quit");
            int input = int.Parse(Console.ReadLine());
            while (true)
            {
                switch (input)
                {
                    //Add Car
                    case 1:
                        string platenumber = CarAdder.CarPlateNumber();
                        string carbrand = CarAdder.CarBrand();
                        string carmodel = CarAdder.CarModel();
                        int caryear = CarAdder.CarYear();
                        int fueltype = CarAdder.FuelType();
                        int price = CarAdder.CarPrice();
                        int color = CarAdder.CarColor();

                        //If specific car exists in the database with same platenumber, we print specific error message on screen
                        //Else we add car to the Dictionary and to the database
                        //This is just an example which only works on runtime

                        if (carsDictionary.ContainsKey(platenumber))
                        {
                            Console.WriteLine("Car with specific plate number already exists");
                        }
                        else
                        {
                            //Add to dictionary
                            carsDictionary.Add(platenumber, carbrand + " " + carmodel + " " + caryear + " " + fueltype + " " + price + " " + color);
                            //Create new instance
                            Car car = new Car(platenumber, carbrand, carmodel, caryear, fueltype, price, color);
                            //Add to the database
                            SqlQuery.Connection();
                            SqlQuery.AddCarToTheDb(car);
                        }
                        Main();
                        break;
                    //Search Car
                    case 2:
                        CarSearcher.CarSearchMenu();
                        break;

                    //Delete Car
                    case 3:
                        SqlQuery.Connection();
                        SqlQuery.DeleteCar();
                        Main();     
                        break;
                    case 4:
                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}
