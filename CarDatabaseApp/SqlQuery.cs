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
        public static List<Car> GetCars { get; set; } = new List<Car>();

        // Connection to Database
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "rc86ezm5";
        private const string DB = "cars";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;

        
        static private NpgsqlCommand SearchByBrandAndPrice = null;
        static private NpgsqlCommand SearchByBrandAndPower = null;
        
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
        
        public static void GetAllCarsFromDb()
        {
            //WIP
            connection.Open();
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
            modelToSearch = CarAdder.FirstLetterToUpperCase(modelToSearch);
            
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
            Console.WriteLine("What fuel type you are looking for? ");
            string[] fueltypes = new string[] { "1- Gasoline", "2 - Diesel"};

            foreach (var item in fueltypes)
            {
                Console.WriteLine(item);
            }
            int fueltypetoseach = int.Parse(Console.ReadLine());

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
            Console.WriteLine("What is your budget? ");
            budget = double.Parse(Console.ReadLine());

            using (searchByPrice = new NpgsqlCommand($"SELECT cars.platenumber, cars.brand, cars.model, cars.year, cars.price, fuel.carpower, colour.colour FROM cars LEFT JOIN colour on colour.colour_id = cars.colorid LEFT JOIN fuel on fuel.fuelid = cars.fuelid WHERE cars.price < {budget}", connection))
            {
                searchByPrice.Prepare();
                try
                {
                    using (NpgsqlDataReader dataReader = searchByPrice.ExecuteReader())

                    while (dataReader.Read())
                    {
                            GetCars.Add(new Car(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt16(3), dataReader.GetInt16(4),  double.Parse(dataReader.GetString(5)), dataReader.GetInt16(6)));

                            foreach (var item in GetCars)
                            {
                                Console.WriteLine(item.PlateNumber , item.Brand , item.Price , item.Model , item.Year , item.Power , item.Color);
                            }
                        //Console.WriteLine($" {dataReader.GetString(0)}, {dataReader.GetString(1)}, {dataReader.GetString(2)}, {dataReader.GetInt16(3)}, {dataReader.GetInt16(4)}, {dataReader.GetString(5)}, { dataReader.GetString(6)}");
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
            //Ask platenumber of the car which user wants to delete
            string carToDelete = CarAdder.CarPlateNumber();
            

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

