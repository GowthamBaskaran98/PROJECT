using System;
namespace HotelBooking
{
    enum Choice
    {
        Display_Hotel = 1,
        Book_Hotel,
        Cancel_Booking,
        Display_Booked_Hotel,
        Log_Out
    };
    class CustomerRepository : HotelRepository
    {
        int index;
        int count;
        HotelRepository hotelRepository = new HotelRepository();
        public void CustomerRepositor(string name)
        {
            condition = false;
            while (condition == false)
            {
                index = 1;
                foreach (string str in Enum.GetNames(typeof(Choice)))
                {
                    Console.WriteLine("Press {0} for {1} ", index, str);
                    index++;
                }
                select = Convert.ToInt16(Console.ReadLine());
                if (select == 1)
                {
                    DisplayHotel();
                }
                else if (select == 2)
                {
                    BookHotel(name);
                }
                else if (select == 3)
                {
                    CancelBooking(name);
                }
                else if (select == 4)
                {
                    DisplayBookedDetail(name);
                }
                else if (select == 5)
                    condition = true;
            }
        }
        public void BookHotel(string customerName)
        {
            count = 0;
            Console.WriteLine(Printer.enterHotelNames);
            hotelName = Console.ReadLine();
            Console.WriteLine(Printer.enterNumberOfRooms);
            numberOfRoom = Convert.ToInt16(Console.ReadLine());
            foreach (HotelOwner h in hotelList)
            {
                if (h.hotelName == hotelName)
                {
                    Console.WriteLine(Printer.booked);
                    h.vacantRoom = (short)(h.vacantRoom - numberOfRoom);
                    admin = new Admin(hotelName, h.ownerName, customerName, numberOfRoom);
                    AdminRepository.BookedList.Add(admin);
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine(Printer.hotelNotFound);
            }
        }
        public void DisplayBookedDetail(string name)
        {
            count = 0;
            foreach (Admin h in AdminRepository.BookedList)
            {
                if (h.customerName == name)
                {
                    h.Display();
                    count++;
                    break;
                }
            }
            if (count == 0)
                Console.WriteLine(Printer.hotelNotFound);
        }
        public void CancelBooking(string name)
        {
            count = 0;
            foreach (Admin h in AdminRepository.BookedList)
            {
                if (h.customerName == name)
                {
                    foreach (HotelOwner k in HotelRepository.hotelList)
                    {
                        if (k.name == h.customerName)
                            k.vacantRoom = (short)(k.vacantRoom + h.numberOfRoom);
                    }
                    AdminRepository.BookedList.Remove(h);
                    Console.WriteLine("Booking cancelled Successfully");
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Hotel not found in this name");
            }
        }
    }
}