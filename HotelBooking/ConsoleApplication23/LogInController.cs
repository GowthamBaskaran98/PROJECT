using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace HotelBooking
{
    class LogInController : RegistrationRepository
    {
        public int count;
        public static List<Registration> userList = new List<Registration>();
        CustomerRepository customer = new CustomerRepository();
        HotelRepository hotels = new HotelRepository();
        //public LogInController()
        //{
        //    register = new Registration("admin", "8778613988", "admin", "Admin");
        //    userList.Add(register);
        //}
        public void LogIn()
        {
            count = 0;
            Console.WriteLine(Printer.enterName);
            name = Console.ReadLine();
            Console.WriteLine(Printer.enterPassword);
            password = Console.ReadLine();
            SqlConnection sqlConnection = Connector.GetDBConnection();
            string sql = "Select * From USER_LOGIN";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter myAdapter = new SqlDataAdapter(sqlCommand);
            DataSet MyDataSet = new DataSet();
            myAdapter.Fill(MyDataSet, "Departments");
            foreach (DataRow myRow in MyDataSet.Tables[0].Rows)
            {
                Registration register = new Registration(myRow[0].ToString().Trim(),myRow[1].ToString().Trim(),myRow[2].ToString().Trim(), myRow[3].ToString().Trim());
                userList.Add(register);
            }
            foreach (Registration r in userList)
            {
                if (r.name == name && r.password == password)
                {
                    if (r.userType.Equals("Customer"))
                    {
                        Console.WriteLine(Printer.validLogin);
                        customer.CustomerRepositor(name);
                        count++;
                        break;
                    }
                    else if (r.userType.Equals("HotelOwner"))
                    {
                        count = 0;
                        Console.WriteLine(Printer.validLogin);
                        foreach (HotelOwner h in HotelRepository.request)
                        {
                            if (h.ownerName == name)
                            {
                                Console.WriteLine(Printer.requestMessage);
                                count++;
                            }
                        }
                        foreach (HotelOwner h in HotelRepository.hotelList)
                        {
                            if (h.ownerName == name)
                            {
                                hotels.Manage(name);
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            hotels.RegisterHotelDetail(name);
                            count++;
                        }
                    }
                    else if (r.userType.Equals("Admin"))
                    {
                        AdminRepository admin = new AdminRepository();
                        count++;
                        break;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine(Printer.invalidLogin);
        }
    }
}
