using System;
using System.Text.Json;

namespace Sol_Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var person = new Person("Kishor", "Naik");
            Console.WriteLine(person);

            // Here we can not set First Name, it will give error
            //p1.FirstName = "Eshaan";

            // but if we want to set First Name Property by using "with" keyword.
            person = person with { FirstName = "Eshaan" };
            Console.WriteLine(person);

            // Destruct records Object into tuples
            var (FirstName, LastName) = person;
            Console.WriteLine($"FirstName : {FirstName} | LastName : {LastName}");

            // Serialize and Deserialize
            var personJson = JsonSerializer.Serialize(person);
            Console.WriteLine(personJson);

            person = JsonSerializer.Deserialize<Person>(personJson);
            Console.WriteLine(person);

            // Employee
            var employee1 = new Employee()
            {
                FirstName = "Kishor",
                LastName = "Naik"
            };

            //employee.FirstName = "Eshaan"; // Not possible to set value becuase of init

            var employee2 = new Employee()
            {
                FirstName = "Kishor",
                LastName = "Naik"
            };

            // Objects comparison
            Console.WriteLine(employee1 == employee2); // true

            var employee3 = employee1 with { FirstName = "Eshaan" };
            Console.WriteLine(employee1 == employee3); // false

            // Inheritance
            Employee employee4 = new SoftwareDeveloper()
            {
                FirstName = "Kishor",
                LastName = "Naik",
                Type = "Database Develoepr"
            };

            Console.WriteLine(employee4);
            Console.WriteLine(employee4.FirstName);
            Console.WriteLine(employee4.LastName);

            SoftwareDeveloper softwareDeveloper = employee4 as SoftwareDeveloper;
            Console.WriteLine(softwareDeveloper);
            Console.WriteLine(softwareDeveloper.FirstName);
            Console.WriteLine(softwareDeveloper.LastName);
            Console.WriteLine(softwareDeveloper.Type);
        }
    }

    public record Person
        (
            string FirstName,
            string LastName
        );

    public record Employee
    {
        public String FirstName { get; init; }
        public String LastName { get; init; }
    }

    public record SoftwareDeveloper : Employee
    {
        public String Type { get; init; }
    }
}