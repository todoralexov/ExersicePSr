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
                errorMessage = "Не е посочено потребителско име! ";
                error(errorMessage);
                u.Role = 0;
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);

            if (emptyPassword == true)
            {
                errorMessage = "Не е посочена парола! ";
                error(errorMessage);
                u.Role = 0;
                return false;
            }

            if(userName.Length < 5)
            {
                errorMessage = "Въвели сте потребителско име с по-малко от 5 символа! ";
                error(errorMessage);
                u.Role = 0;
                return false;
            }

            if (password.Length < 5)
            {
                errorMessage = "Въвели сте парола с по-малко от 5 символа! ";
                error(errorMessage);
                u.Role = 0;
                return false;
            }

            if(UserData.IsUserPassCorrect(userName, password) == null)
            {
                errorMessage = "Няма човек с такова потребителско име или парола!";
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

            Logger.LogActivity("Успешен Login");

            return true;
        }

        static public UserRoles CurrentUserRole
        {
            get;
            private set;
        }
    }     
}