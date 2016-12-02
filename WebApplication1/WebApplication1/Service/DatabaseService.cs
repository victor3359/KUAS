using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Service
{
    public class DatabaseService
    {



        public List<Models.Album> LoadAllAlbum()
        {
            List<Models.Album> result = new List<Models.Album>();

            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Github\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = "Select * from Album";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Album item = new Models.Album();

                item.ID = reader["ID"].ToString();
                item.Genre = reader["Genre"].ToString();
                item.Price = (decimal)reader["Price"];
                item.Title = reader["Title"].ToString();
                item.ImageUrl= reader["ImageUrl"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }
    }
}