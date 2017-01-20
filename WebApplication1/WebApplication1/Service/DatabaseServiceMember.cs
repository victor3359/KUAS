using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Service
{
    public class DatabaseServiceMember
    {

        public List<Models.Member> LoadAllMember()
        {
            List<Models.Member> result = new List<Models.Member>();

            var connection = new System.Data.SqlClient.SqlConnection(@"
Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\victo\Desktop\AspMvc-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from Member
Order by Price";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Member item = new Models.Member();

                item.ID = reader["ID"].ToString();
                item.Number = reader["Number"].ToString();
                item.Name = reader["Name"].ToString();
                item.Price = (decimal)reader["Price"];
                result.Add(item);
            }
            connection.Close();
            return result;
        }
        public Models.Member GetMemberByID(string id)
        {
           Models.Member result = new Models.Member();

            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\victo\Desktop\AspMvc-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select * from Member
Where ID='{0}'", id);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Member item = new Models.Member();

                item.ID = reader["ID"].ToString();
                item.Number = reader["Number"].ToString();
                item.Name = reader["Name"].ToString();
                item.Price = (decimal)reader["Price"];
                result = item;
            }
            connection.Close();
            return result;
        }
        public void CreateMember(Models.Member newMember)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\victo\Desktop\AspMvc-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Member(ID, Number, Name, Price)
VALUES          ('{0}','{1}','{2}',{3})
", newMember.ID, newMember.Number, newMember.Name,  newMember.Price);

            command.ExecuteNonQuery();
            connection.Close();
        }


        public void DeleteMember(string id)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\victo\Desktop\AspMvc-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
DELETE FROM Member
Where ID='{0}'
", id);

            command.ExecuteNonQuery();
            connection.Close();

        }
        public void UpdateMember(Models.Member updateMember)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\victo\Desktop\AspMvc-1230\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
UPDATE          Member
SET             Number='{1}',Name='{2}',Price={3}
Where           ID='{0}'
", updateMember.ID, updateMember.Number, updateMember.Name, updateMember.Price);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}