using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace UserLogin
{
    static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + LoginValidation.CurrentUserRole + ";" + LoginValidation.CurrentUserRole + ";" + activity;
            currentSessionActivities.Add(activityLine);
            
            if (File.Exists("test.txt") == true)
			{
				string s = Console.ReadLine();
				File.AppendAllText("test.txt", s);
			}
        }
        
        static public void checkLog()
        {
        	if (File.Exists("TestFile.txt"))
        	{
        	StreamReader sr = new StreamReader("TestFile.txt");
        	String line = sr.ReadLine();
        	Console.WriteLine(line);
			line = sr.ReadLine();
			Console.WriteLine(line);
			line = sr.ReadLine();
			Console.WriteLine(line);
			sr.Close();
        	}
        	else
        	{
        		Console.WriteLine("No such file or directory");
        	}

    }
        
        static public void GetCurrentSessionActivities()
        {
        	StringBuilder sb = new StringBuilder();
			foreach (var action in currentSessionActivities)
			{
				sb.Append(action);
			}
        }
}
}