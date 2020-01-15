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
            Console.WriteLine("3 - Delete car");
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
                    int color = CarAdder.CarColor();

                    //If specific car exists in the database with same platenumber, we print specific error message on screen
                    //Else we add car to the Dictionary and to the database
                    //This is just an example which doesnt work properly as program is closed/opened again, dictionary is empty, but this is example how we could use dictionary here
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
                    break;
                //Search Car
                case 2:
                    CarSearcher.CarSearchMenu();
                    break;

                //Delete Car
                case 3:
                    SqlQuery.Connection();
                    SqlQuery.DeleteCar();
                    break;
            }
        }
    }
}
