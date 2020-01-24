using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
enum lists
{
    Customer = 1,
    HotelOwner
};
namespace HotelBooking
{
    class RegistrationRepository 
    {
        public string name;
        public string mobileNumber;
        public string password;
        public string userType;
        public int select;
        public bool state;
        public Registration register;
        public void Register()
        {
            try
            {
                Validation validate = new Validation();
                state = false;
                while (state == false)
                {
                    Console.WriteLine(Printer.enterName);
                    name = Console.ReadLine();
                    state = validate.CheckName(name);
                }
                state = false;
                while (state == false)
                {
                    Console.WriteLine(Printer.enterMobileNumber);
                    mobileNumber = Console.ReadLine();
                    state = validate.CheckMobileNumber(mobileNumber);
                }
                state = false;
                while (state == false)
                {
                    Console.WriteLine(Printer.enterPassword);
                    password = Console.ReadLine();
                    state = validate.CheckPassword(password);
                }
                state = false;
                while (state == false)
                {
                    int index = 1;
                    foreach (string str in Enum.GetNames(typeof(lists)))
                    {
                        Console.WriteLine("Press {0} for register as {1} ", index, str);
                        index++;
                    }
                    select = Convert.ToInt16(Console.ReadLine());
                    if (select == 1)
                    {
                        userType = "Customer";
                        state = true;
                    }
                    else if (select == 2)
                    {
                        userType = "HotelOwner";
                        state = true;
                    }
                    else
                    {
                        state = false;
                        Console.WriteLine(Printer.invalidInput);
                    }
                }
                SqlConnection sqlConnection = Connector.GetDBConnection();
                sqlConnection.Open();
                string sql = "REGISTRATION";
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@userId";
                    parameter.Value = name;
                    parameter.SqlDbType = SqlDbType.Char;
                    sqlCommand.Parameters.Add(parameter);
                    parameter = new SqlParameter();
                    parameter.ParameterName = "@mobileNumber";
                    parameter.Value = mobileNumber;
                    parameter.SqlDbType = SqlDbType.Char;
                    parameter.Size = 20;
                    sqlCommand.Parameters.Add(parameter);
                    parameter = new SqlParameter();
                    parameter.ParameterName = "@password";
                    parameter.Value = password;
                    parameter.SqlDbType = SqlDbType.Char;
                    parameter.Size = 20;
                    sqlCommand.Parameters.Add(parameter);
                    parameter = new SqlParameter();
                    parameter.ParameterName = "@userType";
                    parameter.Value = userType;
                    parameter.SqlDbType = SqlDbType.Char;
                    sqlCommand.Parameters.Add(parameter);
                    int retRows = sqlCommand.ExecuteNonQuery();
                    if (retRows >= 1)
                    {
                        Console.WriteLine("Registered Successfully");
                    }
                    else
                    {
                        Console.WriteLine("There is a problem in connecting, Try again later");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message+" "+e.StackTrace);
                Console.ReadLine();
            }
        }
        //public void DisplayCustomerList()
        //{
        //    foreach (Registration k in userList)
        //    {
        //        if (k.userType == "Customer")
        //        {
        //            k.ToString();
        //        }
        //    }
        //}
    }
}
