using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyTaiKhoan
{
    public class UserDao
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CN_Net"].ConnectionString;
        public DataTable GetAllUser()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserInfo", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
        public bool checkUser(string tenDangNhap)
        {
            string sql = @"SELECT COUNT(*) FROM UserInfo WHERE UserName = @tdn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tdn", tenDangNhap);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        public bool Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO UserInfo(UserName,PassWord, FisrtName, LastName, Email, Gender, Address, Avatar) VALUES(@username,@password,@firstname,@lastname,@email,@gender,@address,@avatar)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@gender", user.Gender);
                cmd.Parameters.AddWithValue("@address", user.Address);
                cmd.Parameters.AddWithValue("@avatar", user.AvatarFileName);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public User GetUserByUserName(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM UserInfo WHERE UserName = @tdn ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@tdn", username);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User
                    {
                        Firstname = (string)reader["FisrtName"],
                        Lastname = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        Password = (string)reader["PassWord"],
                        Address = (string)reader["Address"],
                        Gender = (Boolean)reader["Gender"],
                        Username = (string)reader["UserName"]
                    };
                    return user;
                }
                return null;
            }
        }
        public bool UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE UserInfo SET FisrtName = @firstname, LastName = @lastname, Email = @email, Gender = @gender, Address = @address, PassWord = @password , Avatar=@avatar WHERE UserName = @username";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@gender", user.Gender);
                cmd.Parameters.AddWithValue("@address", user.Address);
                cmd.Parameters.AddWithValue("@avatar", user.AvatarFileName);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }

            }
            return false;
        }
        public bool DeleteUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM UserInfo WHERE UserName = @username";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username", username);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }

            }
            return false;
        }
       /* public bool TimKiemUser(string timUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM UserInfo WHERE UserName = @username ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username", timUser);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }

            }
            return false;
        }
        public bool checkUserTim(string timUser)
        {
            string sql = @"SELECT COUNT(*) FROM UserInfo WHERE UserName = @t";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@t", timUser);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }*/

       
    }
    }
