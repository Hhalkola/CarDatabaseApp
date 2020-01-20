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

        // Connection to Database
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "rc86ezm5";
        private const string DB = "cars";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;

        static private NpgsqlCommand getAllCars = null;
        static private NpgsqlCommand searchByPrice = null;
        static private NpgsqlCommand searchCarBrandAndModel = null;
        static private NpgsqlCommand deleteCar = null;
        static private NpgsqlCommand searchCarByBrand = null;
        static private NpgsqlCommand searchByFuelType = null;
        static private NpgsqlConnection connection;
        static private NpgsqlCommand addCar = null;


        //Connecting to database
        public static void Connection()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        //Get all cars from the DB and print on screen
        public static void GetAllCarsFromDb()
        {
            using (getAllCars = new NpgsqlCommand($"SELECT cars.platenumber, cars.brand, cars.model, cars.year, cars.price, fuel.carpower, colour.colour FROM cars LEFT JOIN colour on colour.colour_id = cars.colorid LEFT JOIN fuel on fuel.fuelid = cars.fuelid;", connection))
            {
                try
                {
                    getAllCars.Prepare();
                    using (NpgsqlDataReader dataReader = getAllCars.ExecuteReader())
                        while (dataReader.Read())
                        {
                            Console.WriteLine($" {dataReader.GetString(0)}, {dataReader.GetString(1)}, {dataReader.GetString(2)}, {dataReader.GetInt16(3)}, {dataReader.GetInt16(4)}, {dataReader.GetString(5)}, { dataReader.GetString(6)}");
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public static void SearchByCarBrand()
        {
            //Ask brand
            Console.WriteLine("What brand cars you want to search?" );
            string brandToSearch = Console.ReadLine();
            //Convert first letter to upper
            brandToSearch = CarAdder.FirstLetterToUpperCase(brandToSearch);
            //Execute the query
            using (searchCarByBrand = new NpgsqlCommand($"SELECT cars.platenumber, cars.brand, cars.model, cars.year, cars.price, fuel.carpower, colour.colour FROM cars LEFT JOIN colour on colour.colour_id = cars.colorid LEFT JOIN fuel on fuel.fuelid = cars.fuelid WHERE cars.brand = '{brandToSearch}'", connection))
            {
                searchCarByBrand.Prepare();
                try
                {
                    //Print on screen
                    using (NpgsqlDataReader dataReader = searchCarByBrand.ExecuteReader())
                    while (dataReader.Read())
                    {
                        Console.WriteLine($" {dataReader.GetString(0)}, {dataReader.GetString(1)}, {dataReader.GetString(2)}, {dataReader.GetInt16(3)}, {dataReader.GetInt16(4)}, {dataReader.GetString(5)}, { dataReader.GetString(6)}");
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
        
        public static void SearchByBrandAndModel()
        {
            //Ask the brand
            Console.WriteLine("What brand you want to search?");
            string brandToSearch = Console.ReadLine();
            brandToSearch = CarAdder.FirstLetterToUpperCase(brandToSearch);
            //Ask the model
            Console.WriteLine("What model you want to search? ");
            string modelToSearch = Console.ReadLine();
            modelToSearch = modelToSearch.ToUpper();
            
            using (searchCarBrandAndModel = new NpgsqlCommand($"SELECT cars.platenumber, cars.brand, cars.model, cars.year, cars.price, fuel.carpower, colour.colour FROM cars LEFT JOIN colour on colour.colour_id = cars.colorid LEFT JOIN fuel on fuel.fuelid = cars.fuelid WHERE cars.brand = '{brandToSearch}' AND cars.model = '{modelToSearch}'", connection))
            {
                searchCarBrandAndModel.Prepare();
                try
                {
                    using (NpgsqlDataReader dataReader = searchCarBrandAndModel.ExecuteReader())
                    while (dataReader.Read())
                    {
                        Console.WriteLine($" {dataReader.GetString(0)}, {dataReader.GetString(1)}, {dataReader.GetString(2)}, {dataReader.GetInt16(3)}, {dataReader.GetInt16(4)}, {dataReader.GetString(5)}, { dataReader.GetString(6)}");
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
        public static void SearchCarByFuelType()
        {
            //Ask the fuel type user wants to search
            Console.WriteLine("What fuel type you are looking for? ");
            string[] fueltypes = new string[] { "1- Gasoline", "2 - Diesel"};

            foreach (var item in fueltypes)
            {
                Console.WriteLine(item);
            }
            int fueltypetoseach = int.Parse(Console.ReadLine());
            //Execute the query to the db and print results
            using (searchByFuelType = new NpgsqlCommand($"SELECT cars.platenumber, cars.brand, cars.model, cars.year, cars.price, fuel.carpower, colour.colour FROM cars LEFT JOIN colour on colour.colour_id = cars.colorid LEFT JOIN fuel on fuel.fuelid = cars.fuelid WHERE cars.fuelid = {fueltypetoseach}", connection))
            {
                searchByFuelType.Prepare();
                try
                {
                    using (NpgsqlDataReader dataReader = searchByFuelType.ExecuteReader())
                        while (dataReader.Read())
                        {
                            Console.WriteLine($" {dataReader.GetString(0)}, {dataReader.GetString(1)}, {dataReader.GetString(2)}, {dataReader.GetInt16(3)}, {dataReader.GetInt16(4)}, {dataReader.GetString(5)}, { dataReader.GetString(6)}");
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

        public static void SearchCarByPrice()
        {
            double budget;
            //Ask the budget from the user
            Console.WriteLine("What is your budget? ");
            budget = double.Parse(Console.ReadLine());
            //Execute the query to the db and print results
            using (searchByPrice = new NpgsqlCommand($"SELECT cars.platenumber, cars.brand, cars.model, cars.year, cars.price, fuel.carpower, colour.colour FROM cars LEFT JOIN colour on colour.colour_id = cars.colorid LEFT JOIN fuel on fuel.fuelid = cars.fuelid WHERE cars.price < {budget}", connection))
            {
                searchByPrice.Prepare();
                try
                {
                    using (NpgsqlDataReader dataReader = searchByPrice.ExecuteReader())

                    while (dataReader.Read())
                    {
                        Console.WriteLine($" {dataReader.GetString(0)}, {dataReader.GetString(1)}, {dataReader.GetString(2)}, {dataReader.GetInt16(3)}, {dataReader.GetInt16(4)}, {dataReader.GetString(5)}, { dataReader.GetString(6)}");
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
        public static void AddCarToTheDb(Car car)
        {
            using (addCar = new NpgsqlCommand("INSERT INTO cars(platenumber, brand, model, year, fuelid, price, colorid)"
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
                catch (Exception)
                {
                    Console.WriteLine("Car with this platenumber already exists in the database");

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
            //Ask platenumber of the car which user wants to delete
            string carToDelete = CarAdder.CarPlateNumber();
            //Execute the query with the user input
            using (deleteCar = new NpgsqlCommand($"DELETE FROM cars WHERE platenumber = '{carToDelete}';", connection))
            {
                deleteCar.Prepare();
                try
                {
                    using (NpgsqlDataReader dataReader = deleteCar.ExecuteReader());
                    Console.WriteLine("Car deleted from the database");
                    
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

