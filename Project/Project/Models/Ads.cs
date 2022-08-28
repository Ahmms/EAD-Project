using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;
using MongoDB.Bson;
using System.IO;
using System;
using Microsoft.Data.SqlClient;

namespace Project.Models
{
    public class Ads
    {
        public ObjectId _id { get; set; }
        public string city { get; set; }
        public string make { get; set; }
        public string variant { get; set; }
        public string model { get; set; }
        public string registerdIn { get; set; }
        public string eColor { get; set; }
        public string mileage   { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public string sellerName { get; set; }
        public string mobNumber { get; set; }
        public string image { get; set; }
        public IFormFile image1 { get; set; }
        public string userName { get; set; }
        public byte[] photo { get; set; }
        public string longitutde { get; set; }
        public string latitude { get; set; }
    }
    public class AdsFunction
    {
        public static void uploadAd(Ads ad){
            //// Passing the connection string in MongoClient
            //var client = new MongoClient("mongodb+srv://ahmad:K26BnOx7KXJvFo97@cluster0.d0xqt.mongodb.net/?retryWrites=true&w=majority");
            ////Get sample_mflix Database  
            //var db = client.GetDatabase("Project");
            ////Get movies collection  
            //var collection = db.GetCollection<BsonDocument>("Ads");
            //double value = Double.Parse(ad.price) / 100000;
            //ad.price = value.ToString();
            //var user = new BsonDocument {
            //    {"price",ad.price},
            //    {"make",ad.make},
            //    {"model",ad.model},
            //    {"variant",ad.variant},
            //    {"mileage",ad.mileage},
            //    {"mobNumber",ad.mobNumber },
            //    {"city",ad.city},
            //    {"eColor",ad.eColor},
            //    {"description",ad.description},
            //    {"registerdIn",ad.registerdIn},
            //    {"sellerName",ad.sellerName},
            //    {"userName",ad.userName },
            //    {"photo",ad.photo}
            //};
            //collection.InsertOneAsync(user);
            //var result = collection.Find(user).FirstOrDefault();
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "INSERT INTO AdsData (city,model,make,variant,registerdIn,eColor,mileage,price,description,mobNumber,userName,image) VALUES ('" + ad.city + "','" + ad.model + "','" + ad.make + "','" + ad.variant + "','" + ad.registerdIn + "','" + ad.eColor + "','" + ad.mileage + "','" + ad.price + "','" + ad.description + "','" + ad.mobNumber + "','" + ad.userName + "','"+ad.image+"')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteReader();
        }
        public static string getId()
        {
            string str="0";
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "Select * from AdsData";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                str = Convert.ToString(dr[0]);
            }
            return str;
        }
    }

}
