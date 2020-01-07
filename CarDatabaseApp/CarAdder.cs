﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace CarDatabaseApp
{
    class CarAdder
    {
        public static string CarBrand()
        {
            string carBrand;
            Console.WriteLine("Give brand: ");
            carBrand = Console.ReadLine();

            //WIP
            FirstLetterToUpperCase(carBrand);
        }
        public static string CarModel()
        {
            Console.WriteLine("Car model: ");
            return Console.ReadLine();
        }
        public static int CarYear()
        {
            int year = 0;
            int minimumyear = 1900;

                while (true)
                {
                    Console.WriteLine("Year of manufacturing: ");
                    try
                    {
                        year = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if(year > minimumyear)
                    {
                    return year;
                    }
                }
        }
        public static int FuelType()
        {
            string[] fueltypes = new string[] { "1- Gasoline", "2 - Diesel", "3 - Hybrid" };
            int fueltype =0;

            while (true)
            {
                Console.WriteLine("Fuel type: ");
                
                //Loop through items in array
                foreach (var item in fueltypes)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    fueltype = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
                if (fueltype >= 1 && fueltype <= fueltypes.Length)
                {
                    return fueltype;
                }
                
            }
        }
        public static double CarPrice()
        {
            while (true)
            {
                double carprice = 0;
                double minimumprice = 50;
                Console.WriteLine("Give price: ");
                try
                {
                    carprice = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (carprice > minimumprice)
                {
                    return carprice;
                }
            }
        }
        public static string CarColor()
        {
            Console.WriteLine("Give color: ");
            return Console.ReadLine();
        }

        public static string  CarPlateNumber()
        {
            //We use Regex to apply specific rule that registerplate has to be
            //First 3 must be letters from a-z
            //Then next 3 must be numbers from 0-9
            //We convert user input to Uppercase to make method more flexible
            Regex regex = new Regex("^[A-Z]{3}[0-9]{3}$");
            string userInput ="";
            string userInputToUpper = "";

            while (true)
            {
                Console.WriteLine("Give platenumber in Format 'AAA123'");
                try
                {        
                    userInput = Console.ReadLine();
                    userInputToUpper = userInput.ToUpper();
                    var result = Regex.IsMatch(userInputToUpper, "^[A-Z]{3}[0-9]{3}$");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (Regex.IsMatch(userInputToUpper, regex.ToString()))
                {
                    return userInputToUpper;
                }
                else
                {
                    Console.WriteLine("Wrong format, type plate number in format AAA123");
                }
            }
        }
        //WIP
        public static string FirstLetterToUpperCase(string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
