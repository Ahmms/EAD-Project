using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Project.Models;
namespace Project.Models
{
    public class Home_Class
    {
        
        public List<SignUp> DisplayUsers()
        {
            List<SignUp> users = new List<SignUp>();
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM UserData";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                SignUp su = new SignUp();
                su.firstName = Convert.ToString(dr[1]);
                su.secondName = Convert.ToString(dr[2]);
                su.email = Convert.ToString(dr[3]);
                su.password = Convert.ToString(dr[4]);
                su.gender = Convert.ToString(dr[5]);
                su.phone_no = Convert.ToString(dr[6]);
                users.Add(su);
            }
            return users;
        }
    }
}
