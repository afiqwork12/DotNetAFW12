using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace UnderstandingADOApplication
{
    class User
    {
        string password;
        public string Username { get; set; }
        public string Password 
        { 
            get
            {
                string mask = password.Substring(1, 2) + "**..";
                return mask;
            }
            set
            {
                password = value;
            }
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return
                "Username: " + Username +
                "\nPassword: " + Password +
                "\nName: " + Name +
                "\nAge" + Age;
        }
    }
    class Program
    {
        SqlConnection conn;
        SqlCommand cmdInsert,cmdSelect;
        public Program()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            //conn.Open();
            //Console.WriteLine("Connected");
        }
        //void ReadUsersFromDB()
        //{
        //    List<User> users = new List<User>();
        //    cmdSelect = new SqlCommand("proc_GetAllUsers", conn);
        //    cmdSelect.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        if (conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //        conn.Open();
        //        IDataReader reader = cmdSelect.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            User user = new User();
        //            user.Username = reader[0].ToString();
        //            user.Password = reader[1].ToString();
        //            user.Name = reader[2].ToString();
        //            user.Age = Convert.ToInt32(reader[3]);
        //            users.Add(user);
        //        }
        //        PrintAllUsers(users);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        User TakeUserDetailsFromConsole()
        {
            User user = new User();

            Console.WriteLine("Please enter your preferred username");
            
            do
            {
                user.Username = Console.ReadLine();
                if (user.Username != "")
                {
                    break;
                }
                Console.WriteLine("Username cannot be blank");
            } while (true);
            do
            {
                Console.WriteLine("Please enter your password");
                string password = Console.ReadLine();
                Console.WriteLine("Please enter your retype your password");
                if (password == Console.ReadLine())
                {
                    user.Password = password;
                    break;
                }
                Console.WriteLine("Password Mismatch");
                Console.WriteLine("Try again");
            } while (true);
            Console.WriteLine("Please enter your name");
            user.Name = Console.ReadLine();
            do
            {
                user.Name = Console.ReadLine();
                if (user.Name != "")
                {
                    break;
                }
                Console.WriteLine("Name cannot be blank");
            } while (true);
            Console.WriteLine("Please enter your age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Try again");
            }
            user.Age = age;
            return user;
        }
        void RegisterUser()
        {
            cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "insert into tblUser values(@un, @pass, @name, @age)";
            cmdInsert.Connection = conn;
            User user = TakeUserDetailsFromConsole();
            try
            {
                cmdInsert.Parameters.AddWithValue("@un", user.Username);
                cmdInsert.Parameters.AddWithValue("@pass", user.Password);
                cmdInsert.Parameters.AddWithValue("@name", user.Name);
                cmdInsert.Parameters.AddWithValue("@age", user.Age);
                //cmdInsert.Parameters.Add("@un", SqlDbType.VarChar, 20);
                //cmdInsert.Parameters.Add("@pass", SqlDbType.VarChar, 20);
                //cmdInsert.Parameters.Add("@name", SqlDbType.VarChar, 20);
                //cmdInsert.Parameters.Add("@age", SqlDbType.Int);
                conn.Open();
                int result = cmdInsert.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("User Registered");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not insert");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        void UpdatePassword()
        {
            cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "UPDATE tblUser\n";
            cmdInsert.CommandText += "SET password=@pass\n";
            cmdInsert.CommandText += "WHERE userid=@un";
            cmdInsert.Connection = conn;
            string username, password;
            TakeUsernameAndPassword(out username, out password);
            try
            {
                cmdInsert.Parameters.AddWithValue("@pass", password);
                cmdInsert.Parameters.AddWithValue("@un", username);
                conn.Open();
                int result = cmdInsert.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Password Updated");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        private static void TakeUsernameAndPassword(out string username, out string password)
        {
            Console.WriteLine("Please enter your username");
            do
            {
                username = Console.ReadLine();
                if (username != "")
                {
                    break;
                }
                Console.WriteLine("username cannot be blank");
            } while (true);
            Console.WriteLine("Please enter your new password");
            do
            {
                password = Console.ReadLine();
                if (password != "")
                {
                    break;
                }
                Console.WriteLine("password cannot be blank");
            } while (true);
        }
        //void PrintAllUsers(ICollection<User> users)
        //{
        //    if (users == null || users.Count < 0)
        //    {
        //        Console.WriteLine("No users added yet");
        //    }
        //    else
        //    {
        //        foreach (var item in users)
        //        {
        //            Console.WriteLine(item);
        //        }
        //    }
        //}

        void ReadUsersFromDB_Connected()
        {
            List<User> users = new List<User>();
            cmdSelect = new SqlCommand("proc_GetAllUsers", conn);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                IDataReader reader = cmdSelect.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Username = reader[0].ToString();
                    user.Password = reader[1].ToString();
                    user.Name = reader[2].ToString();
                    user.Age = Convert.ToInt32(reader[3].ToString());
                    users.Add(user);
                }
                PrintAllUSers(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        void ReadUsersFromDB_DisConnected()
        {
            List<User> users = new List<User>();
            cmdSelect = new SqlCommand("proc_GetAllUsers", conn);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdSelect;
                adapter.Fill(ds, "myUsers");//open connection->Fetch the data->put it in the dataset-> disconnect from database
                conn.Close();
                foreach (DataRow item in ds.Tables["myUsers"].Rows)
                {
                    User user = new User();
                    user.Username = item["userid"].ToString();
                    user.Password = item[1].ToString();
                    user.Name = item[2].ToString();
                    user.Age = Convert.ToInt32(item[3].ToString());
                    users.Add(user);
                }
                PrintAllUSers(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {

            }
        }
        void PrintAllUSers(ICollection<User> users)
        {
            if (users == null || users.Count == 0)
            {
                Console.WriteLine("No users added yet");
                return;
            }
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.RegisterUser();
            //p.UpdatePassword();
            //p.ReadUsersFromDB_Connected();
            p.ReadUsersFromDB_DisConnected();
            Console.ReadLine();

        }
    }
}
