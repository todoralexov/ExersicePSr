using System;

namespace StudentRepository
{
	/// <summary>
	/// Description of Student.
	/// </summary>
	public class Student
	{
		public String Name;
		public String SurName;
		public String LastName;
		public String Faculty;
		public String Speciality;
		public String Degree;
		public String Status;
		public String FNumber;
		public Int32 Course;
		public Int32 Stream;
		public Int32 Group;
		public DateTime Zaverka;
		public DateTime TermPayed;
		
		public Student(String name, String surName, String lastName, String faculty, String speciality, String degree, String status,
		            String fNumber, Int32 course, Int32 stream, Int32 _group, DateTime zaverka, DateTime termPayed)
        {
			Name = name;
			SurName = surName;
			LastName = lastName;
			Faculty = faculty;
			Speciality = speciality;
			Degree = degree;
			Status = status;
			FNumber = fNumber;
			Course = course;
			Stream = stream;
			Group = _group;
			Zaverka = zaverka;
			TermPayed = termPayed;
        }
		        
		public Student()
		{
		}
	}
}