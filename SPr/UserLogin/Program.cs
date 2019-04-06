using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.IO;

namespace UserLogin
{
    class Program
    {
        static public void displayError(String error)
        {
            Console.WriteLine("Error occured: " + error + " !!!!!!");
        }

        static public void adminFunc()
        {
            string opt;
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change user role");
            Console.WriteLine("2: Change user activity");
            Console.WriteLine("3: User list");
            Console.WriteLine("4: Check log activity");
            Console.WriteLine("5: Check current activity");
            opt = Console.ReadLine();
            Int32 option = Int32.Parse(opt);

            switch (option)
            {
                case 0:
                    break;
                case 1:
                    changeUserRole();
                    break;
                case 2:
                    changeUserActivity();
                    break;
                case 3:
                    ConcurrentDictionary<String, int> allUsers = UserData.allUsersUsernames();
                    foreach (var currentUser in allUsers)
                    {
                        Console.WriteLine(currentUser.Key);
                        Console.WriteLine(UserData.TestUsers[currentUser.Value]);
                    }
                    break;
                case 4:
                    Logger.checkLog();
                    break;
                case 5:
                    //Logger.GetCurrentSessionActivities();
                    Console.WriteLine("Enter filter for log: ");
                    String criteria = Console.ReadLine();
                    String currentLogData = Logger.GetCurrentSessionActivities(criteria);
                    Console.WriteLine(currentLogData);
                    break;
            }
        }


        public static void changeUserRole()
        {
            Console.WriteLine("Enter user name, which role you want to change: ");
            String userName;
            userName = Console.ReadLine();
            Console.WriteLine("Choose a new role: ");
            String role;
            role = Console.ReadLine();
            Int32 newRole = Int32.Parse(role);
            UserRoles roleNew = (UserRoles)newRole;

            ConcurrentDictionary<String, int> allUsers = UserData.allUsersUsernames();
            UserData.AssignUserRole(allUsers[userName], roleNew);
        }

        public static void changeUserActivity()
        {
            Console.WriteLine("Enter user name, which activity you want to change: ");
            String userName = Console.ReadLine();
            Console.WriteLine("Choose new activity date: ");
            String date = Console.ReadLine();
            DateTime dt = DateTime.Parse(date);

            ConcurrentDictionary<String, int> allUsers = UserData.allUsersUsernames();
            UserData.SetUserActiveTo(allUsers[userName], dt);
        }

        static void Main(string[] args)
        {   
            Console.WriteLine("Please, enter your user name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Please, enter your password: ");
            string password = Console.ReadLine();

            LoginValidation.ActionOnError actionOnError = new LoginValidation.ActionOnError(displayError);

            LoginValidation login = new LoginValidation(userName, password, actionOnError);
           

            User obj = new User();

            if (login.ValidateUserInput(ref obj) == true)
            {
                Console.WriteLine(obj.Username);
                Console.WriteLine(obj.Password);
                Console.WriteLine(obj.FakNum);
                Console.WriteLine(obj.Created);
                Console.WriteLine(obj.Active);
               // Console.WriteLine(obj.Role);

                switch (obj.Role)
                {
                    case 0:
                        Console.WriteLine("Hello, {0}! ", LoginValidation.CurrentUserRole);
                        break;
                    case 1:
                        Console.WriteLine("Hello, {0}! ", LoginValidation.CurrentUserRole);
                        adminFunc();
                        break;
                    case 2:
                        Console.WriteLine("Hello, {0}! ", LoginValidation.CurrentUserRole);
                        adminFunc();
                        break;
                    case 3:
                        Console.WriteLine("Hello, {0}! ", LoginValidation.CurrentUserRole);
                        break;
                }
               
            }
            else
                switch (obj.Role)
                {
                    case 0:
                        Console.WriteLine("Hello, {0}! ", LoginValidation.CurrentUserRole);
                        break;
                }
        }
    }
}