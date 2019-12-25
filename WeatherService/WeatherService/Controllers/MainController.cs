﻿using System;
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
                MongoClient client = new MongoClient("mongodb+srv://Angkor:Casares7735@cluster0-weh6k.gcp.mongodb.net/TestMeLi?retryWrites=true&w=majority");
                IMongoDatabase db = client.GetDatabase("TestMeLi");
                IMongoCollection<WeatherReport> pronostico = db.GetCollection<WeatherReport>("Pronostico");

                FilterDefinition<WeatherReport> filters = Builders<WeatherReport>.Filter.Eq("_id", new ObjectId("5e0390e96f8924822ff7fb83"));
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

        //public DayReport GetDay(int id)
        //{
        //    return report.WeatherPerDay[id];
        //}
    }
}
