using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"sum of the numbers: {numbers.Sum()}");
            //TODO: Print the Average of numbers
            Console.WriteLine($"average of the numbers: {numbers.Average()}");
            //TODO: Order numbers in ascending order and print to the console
            var numbersOrdered = numbers.OrderBy(i=>i);
            Console.WriteLine("numbers ordered ascending: ");
            foreach(var v in numbersOrdered) Console.WriteLine(v);
            //TODO: Order numbers in descending order and print to the console
            var n1 = numbers.OrderByDescending(i => i);
            Console.WriteLine("numbers ordered descending: ");
            foreach (var v in n1) Console.WriteLine(v);
            //TODO: Print to the console only the numbers greater than 6
            var n2=numbers.Where(i => (i > 6));
            Console.WriteLine("numbers >6");
            foreach (var v in n2) Console.WriteLine(v);
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var ordered = numbers.OrderBy(i => i).Take(4);
            Console.WriteLine("first four numbers from ascending list.");
            foreach (var i in ordered) {
                Console.WriteLine(i);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 34;
            var n3 = numbers.OrderByDescending(i => i);
            Console.WriteLine("new index 4, descending order: ");
            foreach (var v in n3) Console.WriteLine(v);
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var fullNameList = employees.Where(employee => (employee.FirstName[0] == 'C' || employee.FirstName[0] == 'S')).OrderBy(employee => employee.FirstName);
            Console.WriteLine("full names starting with C or S,ascending: ");
            foreach (var v in fullNameList) Console.WriteLine(v.FullName);
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var ageList = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).OrderBy(employee => employee.FirstName);
            Console.WriteLine("full names and ages where age >26 and ordered by age then first name.");
            foreach (var v in ageList) Console.WriteLine($"{v.FullName},{v.Age}");
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            int sum = (employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age < 35)).Sum(employee=>employee.YearsOfExperience);
            double average = (employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age < 35)).Average(employee => employee.YearsOfExperience);
            Console.WriteLine("sum and average where yoe<=10 and age>35:");
            Console.WriteLine(sum);
            Console.WriteLine(average);
            //TODO: Add an employee to the end of the list without using employees.Add()
            Employee e = new Employee()
            {
                Age = 45,
                FirstName = "Mark",
                LastName = "Bob",
                YearsOfExperience = 30
            };
            employees.Append(e);
            Console.WriteLine("new list of employees with new added on: ");
            foreach (var v in employees) Console.WriteLine($"{v.LastName},{v.FirstName},{v.FullName},{v.YearsOfExperience},{v.Age}");

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
