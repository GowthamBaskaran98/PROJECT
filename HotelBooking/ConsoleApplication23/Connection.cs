using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace HotelBooking
{
    class DBSQLServerUtil
    {
        public static SqlConnection GetDBConnection(string connectionString)
        {
            try
            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                return sqlConnection;
            }
            catch (Exception exCon)
            {
                Console.WriteLine("Unable to connect to database: {0}", exCon);
                return null;
            }
        }
    }
    class Connector
    {
        public static SqlConnection GetDBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            return DBSQLServerUtil.GetDBConnection(connectionString);
        }
    }
    class Program : Connector
    {
        public enum Option { Add = 1, Update = 2, Delete = 3, View = 4, Exit = 5 };
        public static string name;
        public static double mobileNumber;
        public static string password;
        public static string userType;
        public static int hotelId;
        public static int readChoice;
        public static string hotelName;
        public static string hotelAddress;
        public static short vacantRoom;
        public static short roomSize;
        public static string hotelService;
        public static int pricePerDay;
        public static short numberOfRoom;
        public static short bookedRoom = 0;
        public static int select;
        public static bool condition = true;
        //public void Start()
        //{
        //    SqlConnection sqlConnection = Connector.GetDBConnection();
        //    sqlConnection.Open();
        //    Console.WriteLine("Connection Established!!!");
        //    while (condition == true)
        //    {
        //        condition = true;
        //        Console.WriteLine("Enter Your Choice [1. Add 2. Update 3. Delete 4. View 5. Exit] : ");
        //        readChoice = Int32.Parse(Console.ReadLine());
        //        Option myChoice = (Option)readChoice;
        //        if (myChoice == Option.Add)
        //        {
        //            AddCustomer(sqlConnection);
        //        }
        //        else if (myChoice == Option.Update)
        //        {
        //            UpdateCustomer(sqlConnection);
        //        }
        //        else if (myChoice == Option.Delete)
        //        {
        //            DeleteCustomer(sqlConnection);
        //        }
        //        else if (myChoice == Option.View)
        //        {
        //            ViewCustomer(sqlConnection);
        //        }
        //        else if (myChoice == Option.Exit)
        //        {
        //            condition = false;
        //        }
        //    }
        //    sqlConnection.Close();
        //}
        public static void User_Register(SqlConnection sqlConnection, Registration data)
        {
            string sql = "REGISTRATION";
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                Console.WriteLine(Printer.enterSize);
                parameter.ParameterName = "@name";
                parameter.Value = name = data.name;
                parameter.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(parameter);
                Console.WriteLine(Printer.enterHotel);
                parameter = new SqlParameter();
                parameter.ParameterName = "@mobileNumber";
                parameter.Value = hotelName = Console.ReadLine();
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                Console.WriteLine(Printer.enterAddress);
                parameter = new SqlParameter();
                parameter.ParameterName = "@hotelAddress";
                parameter.Value = hotelAddress = Console.ReadLine();
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        Console.WriteLine(Printer.enterVacantRoom);
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@vacantRoom";
                        parameter.Value = vacantRoom = Convert.ToInt16(Console.ReadLine());
                        parameter.SqlDbType = SqlDbType.Char;
                        parameter.Size = 20;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        Console.WriteLine(Printer.enterSize);
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@roomSize";
                        parameter.Value = roomSize = Convert.ToInt16(Console.ReadLine());
                        parameter.SqlDbType = SqlDbType.Int;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.WriteLine(Printer.enterService);
                parameter = new SqlParameter();
                parameter.ParameterName = "@hotelService";
                parameter.Value = hotelService = Console.ReadLine();
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        Console.WriteLine(Printer.enterPrice);
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@pricePerDay";
                        parameter.Value = pricePerDay = Convert.ToInt32(Console.ReadLine());
                        parameter.SqlDbType = SqlDbType.Int;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                parameter = new SqlParameter();
                parameter.ParameterName = "@Action";
                parameter.Value = readChoice;
                parameter.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(parameter);
                Console.WriteLine(Printer.waitingMessage);
                int retRows = sqlCommand.ExecuteNonQuery();
                if (retRows >= 1)
                {
                    Console.WriteLine("Hotel Added");
                }
                else
                {
                    Console.WriteLine("Hotel not Added");
                }
                sqlCommand.Dispose();
            }
        }
        public static void UpdateCustomer(SqlConnection sqlConnection)
        {
            string sql = "STORED_PROCEDURE";
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                Console.WriteLine(Printer.enterId);
                parameter.ParameterName = "@hotelId";
                parameter.Value = hotelId = Convert.ToInt16(Console.ReadLine());
                parameter.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(parameter);
                Console.WriteLine(Printer.enterHotel);
                parameter = new SqlParameter();
                parameter.ParameterName = "@hotelName";
                parameter.Value = hotelName = Console.ReadLine();
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                Console.WriteLine(Printer.enterAddress);
                parameter = new SqlParameter();
                parameter.ParameterName = "@hotelAddress";
                parameter.Value = hotelAddress = Console.ReadLine();
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        Console.WriteLine(Printer.enterVacantRoom);
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@vacantRoom";
                        parameter.Value = vacantRoom = Convert.ToInt16(Console.ReadLine());
                        parameter.SqlDbType = SqlDbType.Char;
                        parameter.Size = 20;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        Console.WriteLine(Printer.enterSize);
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@roomSize";
                        parameter.Value = roomSize = Convert.ToInt16(Console.ReadLine());
                        parameter.SqlDbType = SqlDbType.Int;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.WriteLine(Printer.enterService);
                parameter = new SqlParameter();
                parameter.ParameterName = "@hotelService";
                parameter.Value = hotelService = Console.ReadLine();
                parameter.SqlDbType = SqlDbType.Char;
                parameter.Size = 20;
                sqlCommand.Parameters.Add(parameter);
                condition = false;
                while (condition == false)
                {
                    try
                    {
                        Console.WriteLine(Printer.enterPrice);
                        parameter = new SqlParameter();
                        parameter.ParameterName = "@pricePerDay";
                        parameter.Value = pricePerDay = Convert.ToInt32(Console.ReadLine());
                        parameter.SqlDbType = SqlDbType.Int;
                        sqlCommand.Parameters.Add(parameter);
                        condition = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                parameter = new SqlParameter();
                parameter.ParameterName = "@Action";
                parameter.Value = readChoice;
                parameter.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(parameter);
                Console.WriteLine(Printer.waitingMessage);
                int retRows = sqlCommand.ExecuteNonQuery();
                if (retRows >= 1)
                {
                    Console.WriteLine("Hotel Added");
                }
                else
                {
                    Console.WriteLine("Hotel not Added");
                }
                sqlCommand.Dispose();
            }
        }
        public static void ViewCustomer(SqlConnection sqlConnection)
        {
            string sql = "STORED_PROCEDURE_SELECT";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Action";
            parameter.Value = readChoice;
            parameter.SqlDbType = SqlDbType.VarChar;
            sqlCommand.Parameters.Add(parameter);
            SqlDataAdapter hotelDA = new SqlDataAdapter();
            hotelDA.SelectCommand = sqlCommand;
            DataSet hotelDS = new DataSet();
            hotelDA.Fill(hotelDS, "HOTELLIST");
            foreach (DataRow pRow in hotelDS.Tables["HOTELLIST"].Rows)
            {
                Console.WriteLine("************************************************************************************************************");
                Console.WriteLine("Hotel ID is                      : {0}", pRow["hotelID"]);
                Console.WriteLine("Hotel Name is                    : {0}", pRow["hotelName"]);
                Console.WriteLine("Hotel Address is                 : {0}", pRow["hotelAddress"]);
                Console.WriteLine("Vacant Rooms is                  : {0}", pRow["vacantRoom"]);
                Console.WriteLine("Room Size is                     : {0}", pRow["roomSize"]);
                Console.WriteLine("Service                          : {0}", pRow["hotelService"]);
                Console.WriteLine("Price per Day is                 : {0}", pRow["pricePerDay"]);
                Console.WriteLine("************************************************************************************************************");
            }
            sqlCommand.Dispose();
        }
        public static void DeleteCustomer(SqlConnection sqlConnection)
        {
            string sql = "STORED_PROCEDURE_DELETE";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter();
            Console.WriteLine(Printer.enterId);
            parameter.ParameterName = "@hotelId";
            parameter.Value = hotelId = Convert.ToInt16(Console.ReadLine());
            parameter.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(parameter);
            parameter = new SqlParameter();
            parameter.ParameterName = "@Action";
            parameter.Value = readChoice;
            parameter.SqlDbType = SqlDbType.VarChar;
            sqlCommand.Parameters.Add(parameter);
            int retRows = sqlCommand.ExecuteNonQuery();
            if (retRows >= 1)
            {
                Console.WriteLine("Customer Deleted...");
            }
            else
            {
                Console.WriteLine("Customer not Deleted...");
            }
            sqlCommand.Dispose();
        }
    }
}
