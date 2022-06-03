using System.Drawing;
using System.Drawing.Imaging;
namespace Project.Models
{
    public class Ads
    {
        public string city { get; set; }
        public string make { get; set; }
        public string variant { get; set; }
        public string model { get; set; }
        public string registerdIn { get; set; }
        public string exteriorColor { get; set; }
        public string mileage   { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public string sellerName { get; set; }
        public string mobileNo { get; set; }
        public byte[] ContentImage { get; set; }
    }
}
