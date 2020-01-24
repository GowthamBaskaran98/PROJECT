using System;
using System.Text.RegularExpressions;
namespace HotelBooking
{
    class Validation 
    {
        private short count;
        public bool CheckName(string name)
        {
        //    foreach (Registration k in RegistrationRepository.userList)
        //    {
        //        if (k.name == name)
        //        {
        //            Console.WriteLine("UserName Already Exists");
        //            return false;
        //        }
        //    }
            return true;
        }
        public bool CheckMobileNumber(string mobileNumber)
        {
            count = 0;
            var hasValidNumber = new Regex(@"[6-9][0-9]{9}");
            //foreach (Registration r in RegistrationRepository.userList)
            //{
            //    if (r.mobileNumber.Equals(mobileNumber))
            //    {
            //        Console.WriteLine(Printer.exist);
            //        return false;
            //    }
            //}
            if (hasValidNumber.IsMatch(mobileNumber))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Please Enter a valid mobile number");
                return false;
            }
        }
        public bool CheckPassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (!hasNumber.IsMatch(password))
            {
                Console.WriteLine("Password should contain At least one numeric value");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(password))
            {
                Console.WriteLine("Password should not be less than 8 or greater than 12 characters");
                return false;
            }
            else if (!hasLowerChar.IsMatch(password))
            {
                Console.WriteLine("Password should contain At least one lower case letter");
                return false;
            }
            else if (!hasUpperChar.IsMatch(password))
            {
                Console.WriteLine("Password should contain At least one upper case letter");
                return false;
            }
            else if (!hasSymbols.IsMatch(password))
            {
                Console.WriteLine("Password should contain At least one special case characters");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DisplayHotel()
        {
            throw new NotImplementedException();
        }

        public void DisplayRequest()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
