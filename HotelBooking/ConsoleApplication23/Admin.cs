using System;
namespace HotelBooking
{
    class Admin
    {
        public string name { get; set; }
        public string customerName { get; set; }
        public short numberOfRoom { get; set; }
        public string ownerName { get; set; }
        public string hotelName { get; set; }
        public Admin(string hotelName, string ownerName,string customerName, short numberOfRoom)
        {
            this.hotelName = hotelName;
            this.customerName = customerName;
            this.ownerName = ownerName;
            this.numberOfRoom = numberOfRoom;
        }
        public void Display()
        {
            Console.WriteLine("Customer Name is               : {0}",customerName);
            Console.WriteLine("Customer Name is               : {0}", hotelName);
            Console.WriteLine("Rooms booked is                : {0}",numberOfRoom);
        }
    }
}