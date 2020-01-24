using System;
namespace HotelBooking
{
    class Registration
    {
        public string name { get; set; }
        public string mobileNumber { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public Registration(string name, string mobileNumber, string password, string userType)
        {
            this.name = name;
            this.mobileNumber = mobileNumber;
            this.password = password;
            this.userType = userType;
        }
        public Registration(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public override string ToString()
        {
            Console.WriteLine("Name is                    : {0}", name);
            Console.WriteLine("Mobile number is                    : {0}", mobileNumber);
            Console.WriteLine("Password is                 : {0}", password);
            return "";
        }
    }
}
