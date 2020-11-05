using System;
using System.IO;

namespace progmet_assignment1
{
    class Program
    {
        class Person
        {
            private string name;
            private string phone;
            private string email;
            private string address;

            public Person(string name, string phone, string email, string address)
            {
                this.name = name;
                this.phone = phone;
                this.email = email;
                this.address = address;
            }
            public string GetName()
            {
                return name;
            }
            public string GetPhone()
            {
                return phone;
            }
            public string GetEmail()
            {
                return email;
            }
            public string GetAddress()
            {
                return address;
            }
            //
            public void PrintPerson()
            {
                Console.WriteLine("name = {0}, phone = {1}, email = {2}, address = {3}", GetName(), GetPhone(), GetEmail(), GetAddress());
            }
        }


        static void Main(string[] args)
        {
            string file_name = "C:\\Users\\samka\\source\\repos\\addressbook.txt";
            
            string[] lines = File.ReadAllLines(file_name);

            Person[] addressbook = new Person[lines.Length];

            foreach (string line in lines)
            {
                string[] person = line.Split(' ');
                Console.WriteLine(person[0] + person[1]);
            }

           




            Console.ReadKey();
        }
    }
}
