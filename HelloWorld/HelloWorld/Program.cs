﻿using System;
namespace ConstructorDemo
{
    class Employee
    {
        public int Id, Age;
        public string Address, Name;
        public bool IsPermanent;

        Employee(int Age)
        {
            this.Age = Age;
        }

        Employee(Employeee obj)
        {
            this.Age = Employee.Age;
        }                           
    }
    class Test
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            Console.WriteLine("Employee Id is:  " + e1.Id);
            Console.WriteLine("Employee Name is:  " + e1.Name);
            Console.WriteLine("Employee Age is:  " + e1.Age);
            Console.WriteLine("Employee Address is:  " + e1.Address);
            Console.WriteLine("Is Employee Permanent:  " + e1.IsPermanent);
            Console.ReadKey();
        }
    }
}