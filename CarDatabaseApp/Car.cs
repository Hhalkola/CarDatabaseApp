using System;
using System.Collections.Generic;
using System.Text;

namespace CarDatabaseApp
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }
        public int Color { get; set; }
        public string PlateNumber { get; set; }

        public Car(string plateNumber, string brand, string model, int year, int power, double price, int color)
        {
            this.PlateNumber = plateNumber;
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Power = power;
            this.Price = price;
            this.Color = color;
        }
    }
}
