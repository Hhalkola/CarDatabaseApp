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
            carBrand = FirstLetterToUpperCase(carBrand);
            return carBrand;
        }
        public static string CarModel()
        {
            string carModel;
            Console.WriteLine("Car model: ");
            carModel = Console.ReadLine();
            carModel = FirstLetterToUpperCase(carModel);
            return carModel;
        }
        public static int CarYear()
        {
            int year = 0;
            int minimumyear = 1900;

                while (true)
                {
                    Console.WriteLine("Year of manufacturing: ");
                    Console.WriteLine("Smallest possible value is 1900");
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
            string[] fueltypes = new string[] { "1- Gasoline", "2 - Diesel"};
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
                    Console.WriteLine(ex.Message);
                }
                if (fueltype >= 1 && fueltype <= fueltypes.Length)
                {
                    return fueltype;
                }
                
            }
        }
        public static int CarPrice()
        {
            while (true)
            {
                int carprice = 0;
                int minimumprice = 50;
                Console.WriteLine("Give price: ");
                Console.WriteLine("Minimum price is 50");
                try
                {
                    carprice = int.Parse(Console.ReadLine());
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
        public static int CarColor()
        {
            while (true)
            {
                string[] colors = new string[] { "1 - Black", "2 - Red", "3 - Blue", "4 - Yellow", "5 - Grey", "6 - White" };
                int carColor =0;
                Console.WriteLine("Give color: ");
                foreach (var item in colors)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    carColor = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (carColor >= 1 && carColor <= colors.Length)
                {
                    return carColor;
                }               
            }
        }

        public static string  CarPlateNumber()
        {
            //We use Regex to apply specific rule that registerplate has to be
            //First 3 must be letters from a-z
            //Then next 3 must be numbers from 0-9
            //We convert user input to Uppercase to make method more flexible
            Regex regex = new Regex("^[A-Z]{3}[0-9]{3}$");
            string userInput;
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
        //We use this method to convert strings so they always have first letter in capital and rest lower case
        public static string FirstLetterToUpperCase(string input)
        {
            input = input[0].ToString().ToUpper() + input.Substring(1);
            return input.ToString();
        }
    }
}
