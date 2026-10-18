
using System;

namespace HW2
{
    public class Program
    {
        public static Person InputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrWhiteSpace(sSalary))
            {
                throw new Exception("You must input Salary.");
            }

            double salary;
            bool isNumber = double.TryParse(sSalary, out salary);

            if (!isNumber)
            {
                throw new Exception("You must input digit.");
            }

            if (salary <= 0)
            {
                throw new Exception("Salary is greater than zero");
            }

            return new Person(name, address, salary);
        }

        public static void DisplayPersonInfo(Person person)
        {
            Console.WriteLine($"Name:{person.Name}");
            Console.WriteLine($"Address:{person.Address}");
            Console.WriteLine($"Salary:{person.Salary:F1}");
            Console.WriteLine();
        }

        public static Person[] SortBySalary(Person[] persons)
        {
            if (persons == null || persons.Length == 0)
            {
                throw new Exception("Can't Sort Person");
            }

            int n = persons.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (persons[j].Salary > persons[j + 1].Salary)
                    {
                        Person temp = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j + 1] = temp;
                    }
                }
            }
            return persons;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("=====Management Person programer=====");
            Person[] persons = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Input Information of Person");
                }

                Console.Write("Please input name:");
                string name = Console.ReadLine();

                Console.Write("Please input address:");
                string address = Console.ReadLine();

                Person person = null;
                while (person == null)
                {
                    Console.Write("Please input salary:");
                    string sSalary = Console.ReadLine();

                    try
                    {
                        person = InputPersonInfo(name, address, sSalary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                persons[i] = person;

                if (i < 2)
                {
                    Console.WriteLine("Input Information of Person");
                }
            }

            try
            {
                persons = SortBySalary(persons);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine("Information of Person you have entered:");
                DisplayPersonInfo(persons[i]);
            }
        }
    }
}