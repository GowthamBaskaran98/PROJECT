using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace HotelBooking
{
    enum options
    {
        Display_Customer = 1,
        LogOut
    };

    class DBSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database,
            string username, string password)
        {
            string connectionString = @"Data Source=" + datasource + ";Initial Catalog=" + database +
                ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            return sqlConnection;
        }
    }
    class HotelRepository
    {
        public static List<HotelOwner> hotelList = new List<HotelOwner>();
        public static List<HotelOwner> request = new List<HotelOwner>();
        private byte count = 0;
        public HotelOwner hotel;
        public int hotelId;
        public string hotelName;
        public string hotelAddress;
        public short vacantRoom;
        public short roomSize;
        public string service;
        public int pricePerDay;
        public short numberOfRoom;
        public short bookedRoom = 0;
        public int select;
        public bool condition;
        Validation validate = new Validation();
        public Admin admin;
        public void Manage(string hotelOwnerName)
        {
            condition = false;
            while (condition == false)
            {
                int index = 1;
                foreach (string str in Enum.GetNames(typeof(options)))
                {
                    Console.WriteLine(Printer.info, index, str);
                    index++;
                }
                select = Convert.ToInt16(Console.ReadLine());
                if (select == 1)
                {
                    foreach(Admin k in AdminRepository.BookedList)
                    {
                        if(k.ownerName==hotelOwnerName)
                        {
                            count++;
                            k.Display();
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(Printer.notFound);
                }
                else if (select == 2)
                {
                    condition = true;
                }
            }
        }
        public void RegisterHotelDetail(string ownerName)
        {
            condition = false;
            Console.WriteLine(Printer.enterHotel);
            hotelName = Console.ReadLine();
            Console.WriteLine(Printer.enterAddress);
            hotelAddress = Console.ReadLine();
            while (condition == false)
            {
                try
                {
                    Console.WriteLine(Printer.enterVacantRoom);
                    vacantRoom = Convert.ToInt16(Console.ReadLine());
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
                    roomSize = Convert.ToInt16(Console.ReadLine());
                    condition = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(Printer.enterService);
            service = Console.ReadLine();
            condition = false;
            while (condition == false)
            {
                try
                {
                    Console.WriteLine(Printer.enterPrice);
                    pricePerDay = Convert.ToInt32(Console.ReadLine());
                    condition = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            HotelOwner detail = new HotelOwner(hotelId,hotelName, ownerName, hotelAddress, vacantRoom, roomSize, service, pricePerDay);
            request.Add(detail);
            Console.WriteLine(Printer.waitingMessage);
        }
        public void DisplayHotel()
        {
            foreach (HotelOwner kvp in hotelList)
            {
                kvp.ToString();
                count++;
            }
            if (count == 0)
                Console.WriteLine(Printer.noHotelFound);
        }
    }
}
