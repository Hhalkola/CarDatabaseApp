using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarDatabaseApp
{
    class Car : IComparable <Car>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public string PowerDB { get; set; }
        public string ColorDB { get; }
        public int Price { get; set; }
        public int Color { get; set; }
        public string PlateNumber { get; set; }

        public Car(string plateNumber, string brand, string model, int year, int power, int price, int color)
        {
            this.PlateNumber = plateNumber;
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Power = power;
            this.Price = price;
            this.Color = color;
        }
        public Car(string plateNumber, string brand, string model, int year, int price, string power, string color)
        {
            this.PlateNumber = plateNumber;
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Price = price;
            this.PowerDB = power;
            this.ColorDB = color;
        }

        public int CompareTo(Car other)
        {
            return Brand.CompareTo(other.Brand);
        }
    }
}
