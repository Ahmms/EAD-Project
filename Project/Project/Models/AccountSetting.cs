using MongoDB.Driver;
using MongoDB.Bson;
using System;
using Microsoft.Data.SqlClient;

namespace Project.Models
{
    public class AccountSetting
    {
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
    public class AccountSettingFunctions
    {
        public static void changePassword(AccountSetting cp)
        {
            //// Passing the connection string in MongoClient
            //var client = new MongoClient("mongodb+srv://ahmad:K26BnOx7KXJvFo97@cluster0.d0xqt.mongodb.net/?retryWrites=true&w=majority");
            ////Get sample_mflix Database  
            //var db = client.GetDatabase("Project");
            ////Get movies collection  
            //var collection = db.GetCollection<BsonDocument>("User_Data");
            ////var result = collection.Find("{username:'" + Environment.GetEnvironmentVariable("userId") + "'}");
            //var quizUpdateFilter = Builders<BsonDocument>.Filter.Eq("username", Environment.GetEnvironmentVariable("userId"));
            //var update = Builders<BsonDocument>.Update.Set("password", cp.confirmPassword);
            //var result = collection.UpdateOne(quizUpdateFilter, update);
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "UPDATE UserData SET pswd = "+cp.newPassword+" WHERE mail="+ Environment.GetEnvironmentVariable("userId") + "; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
        }
    }

}
