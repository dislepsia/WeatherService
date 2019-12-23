using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherService.Classes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace WeatherService.Controllers
{
    public class MainController : ApiController
    {
        WeatherReport report = null;

        public MainController()
        {
            try
            {
                //Me conecto a la base para cargar la variable Report
                var client = new MongoClient("mongodb+srv://Angkor:Casares7735@cluster0-weh6k.gcp.mongodb.net/TestMeLi?retryWrites=true&w=majority");
                var db = client.GetDatabase("TestMeLi");
                var pronostico = db.GetCollection<WeatherReport>("Pronostico");

                var filters = Builders<WeatherReport>.Filter.Eq("_id", BsonValue.Create(ObjectId.Parse("5e00bfcf6f8924822fbab818")));

                report = pronostico.Find(filters).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falla consultar los datos a MongoDb Atlas. " + ex.Message);
            }
        }

        public WeatherReport GetAllDays()
        {
            return report;
        }

        //public string GetDay(int id)
        //{
        //    return report.WeatherPerDay[id];
        //}
    }
}
