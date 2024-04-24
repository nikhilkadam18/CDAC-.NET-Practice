using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MySerialD
{
    [Serializable]
    public class Student
    {
        private int _RollNo;
        private String _Name;

        public string Name
        {
            get { return _Name;}
            set { _Name = value; }
        }

        public int RollNo
        {
            get { return _RollNo; }
            set { _RollNo = value; }
        }
        public void SetStdDetails()
        {
            Console.WriteLine("Enter Student name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Entetr RollNo: ");
            RollNo = Convert.ToInt32(Console.ReadLine());
        }
        public string GetStdDetails()
        {
            string str = "Student name is: " + _Name + "  Roll No is: " + _RollNo;
            return str;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\IET\Desktop\DOT_NET\Assignment4_MySerialD\check.txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            Student student = new Student();
            student.SetStdDetails();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, student);
            fs.Close();
            Console.WriteLine("file closed");

            FileStream fs1 = new FileStream(path, FileMode.Open, FileAccess.Read);
            Student s1 = bf.Deserialize(fs1) as Student;
            Console.WriteLine(s1.GetStdDetails());
            fs1.Close();
            Console.WriteLine("Done");
            Console.ReadLine();

        }
      
       
    }
}
