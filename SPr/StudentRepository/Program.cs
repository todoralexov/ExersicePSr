
using System;

namespace StudentRepository
{
	class Program
	{
		public static void Main(string[] args)
		{	
			StudentData obj = new StudentData();
			obj.DataFill();
			Console.WriteLine("Enter FNumber: ");
            String fakultetennomer = Console.ReadLine();
            Student T = StudentData.IsThereStudent(fakultetennomer);
                    Console.WriteLine(T);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}