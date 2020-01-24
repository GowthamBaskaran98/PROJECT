using System;
namespace HotelBooking
{
    enum Options
    {
        Register = 1,
        LogIn,
        Exit
    };
    class Home
    {
        public Home()
        {
            Console.WriteLine(Printer.title);
        }
        public static void Main(String[] args)
        {
            try
            {
                int select;
                bool choice = true;
                Home home = new Home();
                RegistrationRepository register = new RegistrationRepository();
                LogInController Login = new LogInController();
                Storage storage = new Storage();
                //storage.DisplayOwnerList();
                while (choice == true)
                {
                    int index = 1;
                    foreach (string str in Enum.GetNames(typeof(Options)))
                    {
                        Console.WriteLine(Printer.info, index, str);
                        index++;
                    }
                    select = Convert.ToInt16(Console.ReadLine());
                    if (select == 1)
                    {
                        register.Register();
                    }
                    else if (select == 2)
                    {
                        Login.LogIn();
                    }
                    else if (select == 3)
                    {
                        choice = false;
                    }
                    else
                        Console.WriteLine(Printer.invalidInput);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
