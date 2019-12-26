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
    public class WeatherController : ApiController
    {
        WeatherReport report = null;

        public WeatherController()
        {
            try
            {
                //Me conecto a la base para cargar la variable Report
                MongoClient client = new MongoClient("mongodb+srv://Angkor:Casares7735@cluster0-weh6k.gcp.mongodb.net/TestMeLi?retryWrites=true&w=majority");
                IMongoDatabase db = client.GetDatabase("TestMeLi");
                IMongoCollection<WeatherReport> pronostico = db.GetCollection<WeatherReport>("Pronostico");

                FilterDefinition<WeatherReport> filters = Builders<WeatherReport>.Filter.Eq("_id", new ObjectId("5e04c4ad6f8924822f113193"));
                report = pronostico.Find(filters).First();

                //var idString = "5e015f386f8924822fc8a120";
                //var stringFilter = "{ _id:ObjectId('" + idString + "') }";
                //var entityStringFiltered = pronostico.Find(stringFilter);
                //report = entityStringFiltered.First();
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

        public DayReport GetDay(int id)
        {
            if (id >= 0 && id <= 3650)
                return report.WeatherPerDay[id - 1];
            else
                return null;
        }
    }
}
