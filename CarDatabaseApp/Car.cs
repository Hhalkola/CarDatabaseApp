using System;
using System.Collections.Generic;
using System.Text;

namespace CarDatabaseApp
{
    class Car : IComparable
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }

        public Car(string plateNumber, string brand, string model, int year, int power, double price, string color)
        {
            this.PlateNumber = plateNumber;
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Power = power;
            this.Price = price;
            this.Color = color;
        }

        public Car(int id, string plateNumber, string brand, string model, int year, int power, double price, string color)
        {
            this.Id = Id;
            this.PlateNumber = plateNumber;
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Power = power;
            this.Price = price;
            this.Color = color;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
