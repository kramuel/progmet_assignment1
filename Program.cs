using System;
using System.Collections.Generic;
using System.IO;

namespace progmet_assignment1
{
    class Program
    {
        class Person
        {
            private string name = "";
            private string phone = "";
            private string email = "";
            private string address = "";

            public Person(string name, string phone, string email, string address)
            {
                this.name = name;
                this.phone = phone;
                this.email = email;
                this.address = address;
            }
            public Person(string[] s)
            {

                name = s[0];
                phone = s[1];
                email = s[2];
                address = s[3];
                
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
            public string GetPersonString()
            {
                return $"{name}, {phone}, {email}, {address}";
            }
            public void PrintPerson()
            {
                Console.WriteLine("Name = {0}\nPhone = {1}\nEmail = {2}\nAddress = {3}\n", GetName(), GetPhone(), GetEmail(), GetAddress());
            }

            
        }


        static void Main(string[] args)
        {
            //reads from file (du får byta till tomki :) )
            string file_name = "C:\\Users\\samka\\addressbook.txt";

            string[] lines = { };
            if (File.Exists(file_name))
            {
                lines = File.ReadAllLines(file_name);
            }
            else
            {
                Console.WriteLine("No file found called {0}",file_name);
            }

            List<Person> addressbook = new List<Person>();

            foreach (string line in lines)
            {
                //always has 4 strings (depending on input file??)
                string[] personStrings = line.Split(',');
                addressbook.Add(new Person(personStrings));
            }

            foreach (Person P in addressbook)
                P.PrintPerson();





            //print/svae to new file
            SaveToFile(addressbook);

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }

        static void SaveToFile(List<Person> a)
        {
            string new_file_name = "C:\\Users\\samka\\newaddressbook.txt";
            //open file/create file/overwrite
            if (!File.Exists(new_file_name))
            {
                using FileStream fs = File.Create(new_file_name);
                
            }
            //overwrite
            File.WriteAllText(new_file_name, "");
            //write to file
            foreach (Person P in a)
            {
                File.AppendAllText(new_file_name, $"{P.GetPersonString()}\n");
            }

            //loop thorugh Person[] a;

            //close file
        }
    }
}
