using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
//using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
      
        static private List<User> testUsers = new List<User>();
        static private DateTime creationDate = DateTime.Now;
        static private DateTime activeDate = DateTime.MaxValue;


        static private void ResetTestUserData()
        {
            testUsers = new List<User>();
            testUsers.Add(new User("test0", "pass0", "0", 1, creationDate, activeDate));
            testUsers.Add(new User("test1", "pass1", "1", 4, creationDate, activeDate));
            testUsers.Add(new User("test2", "pass2", "2", 4, creationDate, activeDate));
            testUsers.Add(new User("test2", "pass3", "4", 2, creationDate, activeDate));
        }


        static public ConcurrentDictionary<String, Int32> allUsersUsernames()
        {
            ConcurrentDictionary<String, Int32> result = new ConcurrentDictionary<String, Int32>();
            for (Int32 i = 0; i < testUsers.Count; i++)
            {
                result.GetOrAdd(testUsers[i].Username, i);
            }
            return result;
        }

        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return testUsers;
            }
            private set { }
        }

       static public User IsUserPassCorrect(String userName, String password)
       {
          
             
            User user = (from findUser in TestUsers
                         where findUser.Username == userName && findUser.Password == password
                         select findUser).First();
            return user;
        }

        static public void SetUserActiveTo(Int32 index, DateTime newActiveDate)
        {
            
            testUsers[index].Active = newActiveDate;
            Logger.LogActivity("Промяна на активност на " + testUsers[index].Username);
        }

        static public void AssignUserRole(Int32 index, UserRoles ur)
        {
            
            testUsers[index].Role = (Int32)ur;
            Logger.LogActivity("Промяна на роля на " + testUsers[index].Username);
        }
        
    }
}