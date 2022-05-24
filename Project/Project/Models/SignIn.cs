using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Project.Models
{
    public class SignIn
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string message { get; set; }
    }
    public class SignIn_functions
    {
        public static bool credential_verification(SignIn si)
        {
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT COUNT(*) FROM UserData Where mail='"+si.userName+"' and pswd='"+si.password+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if(Convert.ToInt32(dr[0])==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
