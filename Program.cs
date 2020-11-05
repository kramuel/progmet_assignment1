using System;
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
            //
            public void PrintPerson()
            {
                Console.WriteLine("name = {0}, phone = {1}, email = {2}, address = {3}", GetName(), GetPhone(), GetEmail(), GetAddress());
            }

            
        }


        static void Main(string[] args)
        {
            //reads from file
            string file_name = "C:\\Users\\samka\\source\\repos\\addressbook.txt";
            
            string[] lines = File.ReadAllLines(file_name);

            Person[] addressbook = new Person[lines.Length];

            int i = 0;
            foreach (string line in lines)
            {
                //always has 4 strings (depending on input file??)
                string[] personStrings = line.Split(',');
                addressbook[i++] = new Person(personStrings);
                //addressbook[i++] = new Person(person[0], person[1], person[2], person[3]);
            }

            foreach (Person P in addressbook)
                P.PrintPerson();

            //print/svae to new file
            SaveToFile(addressbook);





            Console.ReadKey();
        }

        static void SaveToFile(Person[] a)
        {
            //open file/create file/overwrite

            //write to file

                //loop thorugh Person[] a;

            //close file
        }
    }
}
