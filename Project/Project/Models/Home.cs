using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Project.Models
{
    public class HomeFunctions
    {
        public static List<Ads> getCars()
        {
            //return all cars
            //var client = new MongoClient("mongodb+srv://ahmad:K26BnOx7KXJvFo97@cluster0.d0xqt.mongodb.net/?retryWrites=true&w=majority");
            ////Get sample_mflix Database  
            //var db = client.GetDatabase("Project");
            //var collection = db.GetCollection<Ads>("Ads");
            //List<Ads> products = collection.Find(new BsonDocument()).ToList();
            ////read image from db and add to list
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM AdsData";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            Ads ad = new Ads();
            List<Ads> ads = new List<Ads>();
            while (dr.Read())
            {
                ad.city = Convert.ToString(dr[1]);
                ad.model= Convert.ToString(dr[2]);
                ad.make= Convert.ToString(dr[3]);
                ad.variant = Convert.ToString(dr[4]);
                ad.registerdIn = Convert.ToString(dr[5]);
                ad.eColor = Convert.ToString(dr[6]);
                ad.mileage = Convert.ToString(dr[7]);
                ad.price = Convert.ToString(dr[8]);
                ad.description = Convert.ToString(dr[9]);
                ad.sellerName = Convert.ToString(dr[10]);
                ad.mobNumber = Convert.ToString(dr[11]);
                ad.userName = Convert.ToString(dr[12]);
                ads.Add(ad);
            }
            return ads;
        }
    }
}
