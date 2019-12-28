using System;
using System.Collections.Generic;
using System.Text;

namespace CarDatabaseApp
{
    class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Power { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string PlateNumber { get; set; }
        private const int LettersInPlateNumber = 3;
        private const int NumbersInPlateNumber = 3;
        private const char PlateNumberSeparator = '-';


        public Car(string brand, string model, int year, string power, int price, string color, string type, string plateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Power = power;
            this.Price = price;
            this.Color = color;
            this.Type = type;
            this.PlateNumber = plateNumber;
        }

        //Method to check if plate number is valid
        //Example from here https://github.com/meijastiina/Olio-ohjelmointi_workshops/blob/master/WS6_Cars_Object_Persistance/Car.cs
        protected bool CheckIfPlateNumberIsValid(string PlateNumber)
        {
            bool returnValue = PlateNumber.Length == LettersInPlateNumber + NumbersInPlateNumber + 1;

            for (int i = 0; i < PlateNumber.Length && returnValue; i++)
            {
                if (i < LettersInPlateNumber)
                {
                    //Loop through letters and check if user input is valid
                    if (!Char.IsLetter(PlateNumber[i]))
                    {
                        returnValue = false;
                    }
                }
                else if(i == LettersInPlateNumber)
                {
                    if (PlateNumber[i] != PlateNumberSeparator)
                    {
                        returnValue = false;
                    }
                }
                else
                {
                    if (!Char.IsNumber(PlateNumber[i]))
                    {
                        returnValue = false;
                    }
                }
            }
            return returnValue;
        }
    }
}
