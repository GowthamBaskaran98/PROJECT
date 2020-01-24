using System;
using System.Collections.Generic;
namespace HotelBooking
{
    enum Option
    {
        Manage_Request_List,
        Delete_the_hotel,
        Delete_Customer_Account,
        Delete_HotelOwner_Account,
        Exit
    }
    enum Set
    {
        Accept_Request,
        Delete_Request
    }
    class AdminRepository : HotelRepository
    {
        private int count;
        private string name;
        private bool state;
        Storage storage = new Storage();
        HotelRepository hotelRepository = new HotelRepository();
        public static List<Admin> BookedList = new List<Admin>();
        RegistrationRepository detail = new RegistrationRepository();
        public AdminRepository()
        {
            Console.WriteLine("Admin Account " + Printer.validLogin);
            state = false;
            while (condition == false)
            {
                int index = 1;
                foreach (string str in Enum.GetNames(typeof(Option)))
                {
                    Console.WriteLine(Printer.info, index, str);
                    index++;
                }
                short choice = Convert.ToInt16(Console.ReadLine());
                if (choice == 1)
                {
                    count = 0;
                    state = DisplayRequest();
                    while (state == false)
                    {
                        index = 1;
                        foreach (string str in Enum.GetNames(typeof(Set)))
                        {
                            Console.WriteLine(Printer.info, index, str);
                            index++;
                        }
                        int select = Convert.ToInt16(Console.ReadLine());
                        if (select == 1 || select == 2)
                        {
                            foreach (HotelOwner r in request)
                            {
                                if (r.hotelName == name)
                                {
                                    if (select == 1)
                                    {
                                        r.hotelId = hotelList.Count + 2;
                                        hotelList.Add(r);
                                        request.Remove(r);
                                        Console.WriteLine("Hotel Added Successfully");
                                        break;
                                    }
                                    else if (select == 2)
                                    {
                                        request.Remove(r);
                                        break;
                                    }
                                }
                            }
                            state = true;
                        }
                        else
                            Console.WriteLine(Printer.invalidInput);
                    }
                }
                else if(choice == 2)
                {
                    count = 0;
                    hotelRepository.DisplayHotel();
                    Console.WriteLine(Printer.enterHotel);
                    name = Console.ReadLine();
                    foreach (HotelOwner r in hotelList)
                    {
                        if (r.hotelName.Equals(name))
                        {
                            hotelList.Remove(r);
                            Console.WriteLine(Printer.delete);
                            count++;
                            break;
                        }
                    }
                    if(count==0)
                        Console.WriteLine(Printer.invalidHotel);
                }
                //else if(choice == 3)
                //{
                //    count = 0;
                //    if (RegistrationRepository.userList.Count == 0)
                //    {
                //        Console.WriteLine(Printer.customerNotFound);
                //    }
                //    else
                //    {
                //        detail.DisplayCustomerList();
                //        Console.WriteLine(Printer.enterCustomerName);
                //        name = Console.ReadLine();
                //        foreach (Registration r in RegistrationRepository.userList)
                //        {
                //            if (r.name.Equals(name) && r.userType.Equals("Customer"))
                //            {
                //                RegistrationRepository.userList.Remove(r);
                //                Console.WriteLine(Printer.delete);
                //                count++;
                //                break;
                //            }
                //        }
                //    }
                //    if(count == 0)
                //        Console.WriteLine(Printer.invalidCustomer);
                //}
                //else if(choice == 4)
                //{
                //    if (RegistrationRepository.userList.Count == 0)
                //    {
                //        Console.WriteLine(Printer.invalidOwner);
                //    }
                //    else
                //    {
                //        storage.DisplayOwnerList();
                //        Console.WriteLine(Printer.enterOwnerName);
                //        name = Console.ReadLine();
                //        count = 0;
                //        foreach (Registration r in RegistrationRepository.userList)
                //        {
                //            if (r.name.Equals(name) && r.userType.Equals("Hotel Owner"))
                //            {
                //                RegistrationRepository.userList.Remove(r);
                //                Console.WriteLine(Printer.delete);
                //                count++;
                //                break;
                //            }
                //        }
                //        if(count == 0)
                //            Console.WriteLine(Printer.invalidOwner);
                //    }
                //}
                else if(choice == 5)
                    condition = true;
            }
        }
        public bool DisplayRequest()
        {
            foreach (HotelOwner k in request)
            {
                k.ToString();
                Console.WriteLine(Printer.enterHotel);
                name = Console.ReadLine();
                count++;
            }
            if (count == 0)
            {
                Console.WriteLine(Printer.noRequest);
                return true;
            }
            else
                return false;
        }
    }
}
