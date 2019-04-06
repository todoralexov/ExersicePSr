using System;
using System.Linq;

namespace UserLogin
{
    class LoginValidation
    {
        private String userName;
        private String password;
        private String errorMessage;
        private ActionOnError error;

       
        public delegate void ActionOnError(string errorMsg);


        public LoginValidation(String userName, String password, ActionOnError error)
        {
            this.userName = userName;
            this.password = password;
            this.error = error;
        }
        
        public bool ValidateUserInput(ref User u)
        {
           
            Boolean emptyUserName;
            emptyUserName = userName.Equals(String.Empty);

            if (emptyUserName == true)
            {
                errorMessage = "User name is not entered! ";
                error(errorMessage);
                u.Role = 0;
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);

            if (emptyPassword == true)
            {
                errorMessage = "Password is not entered! ";
                error(errorMessage);
                u.Role = 0;
                return false;
            }

            if(userName.Length < 5)
            {
                errorMessage = "The entered user name has less than 5 symbols! ";
                error(errorMessage);
                u.Role = 0;
                return false;
            }

            if (password.Length < 5)
            {
                errorMessage = "The entered password has less than 5 symbols! ";
                error(errorMessage);
                u.Role = 0;
                return false;
            }

            if(UserData.IsUserPassCorrect(userName, password) == null)
            {
                errorMessage = "No such user name and password!";
                error(errorMessage);
                u.Role = 0;
                return false;
            }


            u.Username = UserData.IsUserPassCorrect(userName, password).Username;
            u.Password = UserData.IsUserPassCorrect(userName, password).Password;
            u.FakNum = UserData.IsUserPassCorrect(userName, password).FakNum;
            u.Role = UserData.IsUserPassCorrect(userName, password).Role;
            u.Created = UserData.IsUserPassCorrect(userName, password).Created;
            u.Active = UserData.IsUserPassCorrect(userName, password).Active;



            CurrentUserRole = (UserRoles)u.Role;

            Logger.LogActivity("Succesful Login");

            return true;
        }

        static public UserRoles CurrentUserRole
        {
            get;
            private set;
        }
    }     
}