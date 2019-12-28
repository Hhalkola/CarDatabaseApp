using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace CarDatabaseApp
{
    class SqlQuery
    {
        // Connection to Database
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "-----";
        private const string DB = "Cars";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;

        static private NpgsqlConnection connection;
        static private NpgsqlCommand GetAllCars = null;
        static private NpgsqlCommand SearchByBrand = null;
        static private NpgsqlCommand SearchByBrandAndModel = null;
        static private NpgsqlCommand SearchByBrandAndPrice = null;
        static private NpgsqlCommand SearchByBrandAndPower = null;
        static private NpgsqlCommand SearchByBrandAndColour = null;
        static private NpgsqlCommand SearchByPrice = null;
        static private NpgsqlCommand SearchByPower = null;
        static private NpgsqlCommand AddCar = null;
        static private NpgsqlCommand DeleteCar = null;

        //Connecting to database
        public static void Connection()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        // kyselyt alapuolella, kesken vielä!
        public static void SearchCarByBrand()
        {
            using (SearchByBrand = new NpgsqlCommand($"SELECT * FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrand.Prepare();

            }
        }

        public static void SearchCarByBrandAndModel()
        {
            using (SearchByBrandAndModel = new NpgsqlCommand($"SELECT * FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndModel.Prepare();

            }
        }

        public static void SearchCarByBrandAndPrice()
        {
            using (SearchByBrandAndPrice = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndPrice.Prepare();

            }
        }

        public static void SearchCarByBrandAndPower()
        {
            using (SearchByBrandAndPower = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndPower.Prepare();

            }
        }

        public static void SearchCarByBrandAndColour()
        {
            using (SearchByBrandAndPower = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndPower.Prepare();

            }
        }


        public static void SearchCarByPrice()
        {
            using (SearchByBrandAndPower = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndPower.Prepare();

            }
        }

        public static void SearchCarByPower()
        {
            using (SearchByBrandAndPower = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndPower.Prepare();

            }
        }

        public static void AddCarToDb()
        {
            using (SearchByBrandAndPower = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndPower.Prepare();

            }
        }

        public static void DeleteCarFromDb()
        {
            using (SearchByBrandAndPower = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndPower.Prepare();

            }
        }
    }
}
