using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CarDatabaseApp
{
    class SqlQuery
    {
        /*
        // Connection to Database
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "-----";
        private const string DB = "Cars";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;

        
        static private NpgsqlCommand SearchByBrandAndPrice = null;
        static private NpgsqlCommand SearchByBrandAndPower = null;
        static private NpgsqlCommand SearchByBrandAndColour = null;
        static private NpgsqlCommand SearchByPower = null;
        */
        static private NpgsqlCommand getAllCars = null;
        static private NpgsqlCommand searchByPrice = null;
        static private NpgsqlCommand searchCarBrandAndModel = null;
        static private NpgsqlCommand deleteCar = null;
        static private NpgsqlCommand searchCarByBrand = null;
        static private NpgsqlConnection connection;
        static private NpgsqlCommand addCar = null;
/*

        //Connecting to database
        public static void Connection()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        */
        public static void GetAllCarsFromDb()
        {
            //WIP
            using (getAllCars = new NpgsqlCommand($"SELECT * FROM cars;", connection))
            {
                getAllCars.Prepare();
                using (NpgsqlDataReader reader = getAllCars.ExecuteReader())
                    while (reader.Read())
                    {
                        Console.WriteLine($" {reader.GetInt16(0)}, {reader.GetString(1)}, {reader.GetString(2)}, {reader.GetString(3)}, {reader.GetInt16(4)}, {reader.GetInt16(5)},{ reader.GetDouble(6)}, { reader.GetString(7)}");
                    }
            }
        }

        public static void SearchByCarBrand()
        {
            Console.WriteLine("What brand cars you want to search?" );
            string brandToSearch = Console.ReadLine();
            brandToSearch = CarAdder.FirstLetterToUpperCase(brandToSearch);
            using (searchCarByBrand = new NpgsqlCommand($"SELECT * FROM cars WHERE brand = {brandToSearch};", connection))
            {
                searchCarByBrand.Prepare();
                using (NpgsqlDataReader dataReader = searchCarByBrand.ExecuteReader())
                while (dataReader.Read())
                    {
                        Console.WriteLine($" {dataReader.GetInt16(0)}, {dataReader.GetString(1)}, {dataReader.GetString(2)}, {dataReader.GetString(3)}, {dataReader.GetInt16(4)}, {dataReader.GetInt16(5)},{ dataReader.GetDouble(6)}, { dataReader.GetString(7)}");
                    }
            }
        }
        
        // etsitään autonmerkin ja mallin perusteella 
        public static void SearchByBrandAndModel()
        {
            //Ask the brand
            Console.WriteLine("What brand you want to search?");
            string brandToSearch = Console.ReadLine();
            brandToSearch = CarAdder.FirstLetterToUpperCase(brandToSearch);
            //Ask the model
            Console.WriteLine("What model you want to search? ");
            string modelToSearch = Console.ReadLine();
            modelToSearch = CarAdder.FirstLetterToUpperCase(modelToSearch);

            using (searchCarBrandAndModel = new NpgsqlCommand($"SELECT * FROM cars WHERE brand = {brandToSearch} AND model = {modelToSearch};", connection))
            {
                searchCarBrandAndModel.Prepare();
                try
                {
                    using (NpgsqlDataReader reader = searchCarBrandAndModel.ExecuteReader());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        /*
        // Search according to brand and price
        public static void SearchByBrandAndPrice()
        {
            using (SearchByBrandAndPrice = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta} AND price = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndPrice.Prepare();
          
            }
        }

        // tässä haetaan autonmerkkiä ja käyttövoimaa ja yhdistetään cars ja carpower taulut
        public static void SearchByBrandAndPower()
        {
            using (SearchByBrandAndPower = new NpgsqlCommand($"SELECT cars.brand, cars.model, cars.year, cars.id_carpower, cars.price, cars.id_colour, cars.type, cars.platenr, carpower.carpower FROM cars LEFT JOIN carpower ON cars.id_carpower = carpower.carpower_id WHERE cars.brand = {tahankayttajanvalintavalikosta} AND carpower.carpower = {tahankayttajanvalintavalikosta};", connection))
            {
                SearchByBrandAndPower.Prepare();
          
            }
        }

        // tässä haetaan autonmerkkiä ja väriä ja yhdistetään cars ja colour taulut
        public static void SearchByBrandAndColour()
        {
            using (SearchByBrandAndColour = new NpgsqlCommand($"SELECT cars.brand, cars.model, cars.year, cars.id_carpower, cars.price, cars.id_colour, cars.type, cars.platenr, colour.colour FROM cars LEFT JOIN colour ON cars.id_colour = colour.colour_id WHERE cars.brand = {tahankayttajanvalintavalikosta} AND colour.colour = {tahankayttajanvalintavalikosta};", connection))            
            {
                SearchByBrandAndColour.Prepare();
          
            }
        }

        // Search by specific budget
        */
        public static void SearchCarByPrice()
        {
            double budget =0;
            Console.WriteLine("What is your budget? ");
            
            while (true)
            {
                try
                {
                    budget = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
            
            //WIP
            using (searchByPrice = new NpgsqlCommand($"SELECT * FROM cars WHERE price < {budget};", connection))
            {
                searchByPrice.Prepare();
                try
                {
                    using (NpgsqlDataReader reader = searchByPrice.ExecuteReader())

                    while (reader.Read())
                    {
                        Console.WriteLine($" {reader.GetInt16(0)}, {reader.GetString(1)}, {reader.GetString(2)}, {reader.GetString(3)}, {reader.GetInt16(4)}, {reader.GetInt16(5)},{ reader.GetDouble(6)}, { reader.GetString(7)}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        /*
        // etsitään käyttövoiman perusteella, yhdistetään cars ja carpower taulut
        public static void SearchByPower()
        {
            using (SearchByPower = new NpgsqlCommand($"SELECT cars.brand, cars.model, cars.year, cars.id_carpower, cars.price, cars.id_colour, cars.type, cars.platenr, carpower.carpower FROM cars LEFT JOIN carpower ON cars.id_carpower = carpower.carpower_id WHERE carpower.carpower = {tahankayttajanvalintavalikosta};    ", connection))
            {
                SearchByPower.Prepare();
          
            }
        }
        */
        public static void AddCarToTheDb(Car car)
        {
            using (addCar = new NpgsqlCommand("INSERT INTO car(platenumber, brand, model, year, fuelid, price, colorid)"
                + "VALUES (@platenumber, @brand, @model, @year, @fuelid, @price, @colorid)", connection))
            {
                addCar.Parameters.AddWithValue("platenumber", car.PlateNumber);
                addCar.Parameters.AddWithValue("brand", car.Brand);
                addCar.Parameters.AddWithValue("model", car.Model);
                addCar.Parameters.AddWithValue("year", car.Year);
                addCar.Parameters.AddWithValue("fuelid", car.Power);
                addCar.Parameters.AddWithValue("price", car.Price);
                addCar.Parameters.AddWithValue("colorid", car.Color);

                try
                {
                    addCar.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
    
        public static void DeleteCar()
        {
            //Print list of cars -> Ask which one to delete
            Console.WriteLine("Which car do you want to remove?" );
            string carToDelete = Console.ReadLine();

            using (deleteCar = new NpgsqlCommand($"DELETE FROM cars WHERE id = {carToDelete};", connection))
            {
                deleteCar.Prepare();
                try
                {
                    using (NpgsqlDataReader dataReader = deleteCar.ExecuteReader());
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
          
            }
        }
    }
}

