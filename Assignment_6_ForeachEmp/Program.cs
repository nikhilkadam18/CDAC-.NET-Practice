using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForeach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            //add 10 emp with names
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter Employee name {i+1}: ");
                string name = Console.ReadLine();
                employees.Add(new Employee { Name = name });
            }

            Console.WriteLine("List of employees: ");
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
            Console.WriteLine("Enter name for update: ");
            string empToSearch = Console.ReadLine();

            //update logic
            Employee empToUpdate = employees.FirstOrDefault(emp=>emp.Name==empToSearch);
            if (empToUpdate != null)
            {
                Console.WriteLine("Enter new name: ");
                string newName = Console.ReadLine();
                empToUpdate.Name = newName;
                Console.WriteLine($"Employee '{empToSearch}' updated to '{newName}'.");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }

            //display updated list
            Console.WriteLine("Updated list is: ");
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
            

        }
    }
    class Employee
    {
        public string Name { get; set; }
    }
}
