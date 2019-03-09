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
            Console.WriteLine("Възникна грешка: " + error + " !!!!!!");
        }

        static public void adminFunc()
        {
            string opt;
            Console.WriteLine("Изберете опция: ");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребителите");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");
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
                    Logger.GetCurrentSessionActivities();
                    break;
            }
        }


        public static void changeUserRole()
        {
            Console.WriteLine("Посочете потребителското име на потребителя, чиято роля искате да промените: ");
            String userName;
            userName = Console.ReadLine();
            Console.WriteLine("Посочете новата роля: ");
            String role;
            role = Console.ReadLine();
            Int32 newRole = Int32.Parse(role);
            UserRoles roleNew = (UserRoles)newRole;

            ConcurrentDictionary<String, int> allUsers = UserData.allUsersUsernames();
            UserData.AssignUserRole(allUsers[userName], roleNew);
        }

        public static void changeUserActivity()
        {
            Console.WriteLine("Посочете потребителското име на потребителя, чиято активност искате да промените: ");
            String userName = Console.ReadLine();
            Console.WriteLine("Посочете нова дата на активност: ");
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