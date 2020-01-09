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
        public string Power { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string PlateNumber { get; set; }

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

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
