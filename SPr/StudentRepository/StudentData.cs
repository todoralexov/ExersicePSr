using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace StudentRepository
{
	/// <summary>
	/// Description of StudentData.
	/// </summary>
	public class StudentData
	{
		DateTime Zaverka = DateTime.Now;
		DateTime TermPayed = DateTime.Now;
			
		public static List<Student> TestStudents = new List<Student>();
		
		public void DataFill()
		{
			TestStudents = new List<Student>();
			TestStudents.Add(new Student("FirstName","SecondName", "ThirdName","Faculty", "Speciality", "Degree", "Status", "1", 1,
		                             80, 90, Zaverka, TermPayed));
		}
		
		 public static Student IsThereStudent(String fakultetenNomer)
       {  
            Student student = (from findStudent in StudentData.TestStudents
                         where findStudent.FNumber == fakultetenNomer
                         select findStudent).FirstOrDefault();
            return student;
        }

		public StudentData()
		{
		}
	}
}
