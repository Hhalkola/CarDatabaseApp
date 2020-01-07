using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Carproject
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

        // kyselyt alapuolella, HUOM! Haut toimii vain, kun isot ja pienet kirjaimet on kirjoitettu
        // niinkuin ne on tauluihin syötetty. Esim BMW, ei toimi Bmw tms.

        // etsitään autonmerkin perusteella
        public static void SearchByBrand()
        {
            using (SearchByBrand = new NpgsqlCommand($"SELECT * FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrand.Prepare();
          
            }
        }

        // etsitään autonmerkin ja mallin perusteella
        public static void SearchByBrandAndModel()
        {
            using (SearchByBrandAndModel = new NpgsqlCommand($"SELECT * FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta} AND model = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByBrandAndModel.Prepare();
          
            }
        }

        // etsitään autonmerkin ja hinnan perusteella
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

        // etsitään hinnan perusteella
        public static void SearchByPrice()
        {
            using (SearchByPrice = new NpgsqlCommand($"SELECT * FROM cars WHERE price = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                SearchByPrice.Prepare();
          
            }
        }

        // etsitään käyttövoiman perusteella, yhdistetään cars ja carpower taulut
        public static void SearchByPower()
        {
            using (SearchByPower = new NpgsqlCommand($"SELECT cars.brand, cars.model, cars.year, cars.id_carpower, cars.price, cars.id_colour, cars.type, cars.platenr, carpower.carpower FROM cars LEFT JOIN carpower ON cars.id_carpower = carpower.carpower_id WHERE carpower.carpower = {tahankayttajanvalintavalikosta};    ", connection))
            {
                SearchByPower.Prepare();
          
            }
        }


        // ei vielä mitään hajua mitä näihin pitää laittaa?!
        public static void AddCar()
        {
            using (AddCar = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                AddCar.Prepare();
          
            }
        }

        public static void DeleteCar()
        {
            using (DeleteCar = new NpgsqlCommand($"SELECT brand FROM cars WHERE brand = {tähänkäyttäjänvalintavalikosta};", connection))
            {
                DeleteCar.Prepare();
          
            }
        }

    */
    }
}

