using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Project.Models
{
    public class ContactUs
    {
        public string Account_Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string mail { get; set; }
        [Required(ErrorMessage = "Required")]
        public string contact { get; set; }
        [Required(ErrorMessage = "Required")]
        public string message { get; set; }

    }
    public class ContactUsFunction
    {
        public static void AddMessage(ContactUs cu)
        {
            // Passing the connection string in MongoClient
            var client = new MongoClient("mongodb+srv://ahmad:K26BnOx7KXJvFo97@cluster0.d0xqt.mongodb.net/?retryWrites=true&w=majority");
            //Get sample_mflix Database  
            var db = client.GetDatabase("Project");
            //Get movies collection  
            var collection = db.GetCollection<BsonDocument>("Messages");
            var user = new BsonDocument
             {
                {"Name",cu.name},
                {"Mail",cu.mail},
                {"Contact",cu.contact},
                {"Message",cu.message}
            };
            collection.InsertOneAsync(user);
        }
    }

}
