using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

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
                return $"{name},{phone},{email},{address}";
            }
            public void PrintPerson()
            {//här kan jag använda private stringsen egentligen right?
                Console.WriteLine("Name = {0}\nPhone = {1}\nEmail = {2}\nAddress = {3}\n", GetName(), GetPhone(), GetEmail(), GetAddress());
            }


        }


        static void Main(string[] args)
        {
            string usrInpt;
            List<Person> addressbook = new List<Person>();
            //reads from this file (du får byta till tomki :) )
            string file_name = "C:\\Users\\samka\\addressbook.txt";
            //saves to this file after quitting program
            string new_file_name = "C:\\Users\\samka\\newaddressbook.txt";

            string[] lines;

            if (File.Exists(file_name))
            {
                lines = File.ReadAllLines(file_name);
            }
            else
            {
                Console.WriteLine("No input-file found called {0}", file_name);
                Console.WriteLine("\nPress any key to exit");
                Console.ReadKey();
                return;
            }

            foreach (string line in lines)
            {
                //always has 4 strings (depending on input file??)
                string[] personStrings = line.Split(',');
                addressbook.Add(new Person(personStrings));
            }



            while (true)
            {
                PrintMenu();

                usrInpt = GetUserInput();

                if (usrInpt == "0")
                    break;

                if (usrInpt == "1")//show menu
                {
                    Console.Clear();
                    foreach (Person P in addressbook)
                        P.PrintPerson();

                    Console.WriteLine("Press any key to go back to menu.");
                    Console.ReadKey();
                }

                if (usrInpt == "2") //add person
                {
                    string[] newPerson = new string[4];
                    Console.Clear();
                    Console.WriteLine("To add a new person, enter information below.");
                    Console.Write("Name(Namn N): ");
                    newPerson[0] = Console.ReadLine();
                    Console.Write("Phone(012345*****): ");
                    newPerson[1] = Console.ReadLine();
                    Console.Write("Email(abcd@defg.ikj): ");
                    newPerson[2] = Console.ReadLine();
                    Console.Write("Address(***vägen 1): ");
                    newPerson[3] = Console.ReadLine();

                    addressbook.Add(new Person(newPerson));

                    Console.WriteLine("You have now added {0} to this addressbook!", newPerson[0]);

                    Console.WriteLine("Press any key to go back to menu.");
                    Console.ReadKey();
                }

                if (usrInpt == "3")//remove person
                {
                    Console.Clear();
                    Console.WriteLine("To remove a person from the addressbook enter name below.");
                    Console.Write("Name(Namn N): ");
                    string remName = Console.ReadLine();
                    //om två har exakt samma namn == RIP 
                    int remIndex = -1;
                    for (int i = 0; i < addressbook.Count; i++)
                    {
                        if (addressbook[i].GetName() == remName)
                        {
                            remIndex = i;
                        }
                    }
                    if (remIndex == -1)
                    {
                        Console.WriteLine("No Person was found with that name.");
                    }
                    else
                    {
                        Console.WriteLine("You have now removed {0} from this addressbook!", addressbook[remIndex].GetName());
                        addressbook.RemoveAt(remIndex);
                    }

                    Console.WriteLine("Press any key to go back to menu.");
                    Console.ReadKey();
                }

            }

            //print/save to new file
            SaveToFile(new_file_name, addressbook);
            Console.WriteLine("Saved info to new file. ({0})", new_file_name);

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("**********Welcome to the addressbook********");
            Console.WriteLine("1: Show people.");
            Console.WriteLine("2: Add Person.");
            Console.WriteLine("3: Remove Person.");
            Console.WriteLine("0: Exit addressbook.");
        }
        static string GetUserInput()
        {
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();

            while (true)
            {
                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "0")
                {
                    break;
                }

                Console.WriteLine("Wrong input, please try again: ");
                userInput = Console.ReadLine();
            }

            return userInput;
        }
        static void SaveToFile(string new_file_name, List<Person> a)
        {

            //open file/create file/overwrite
            FileStream fs = File.Create(new_file_name);
            //FileStream fs = new FileStream(new_file_name,FileMode.Create); är det någon skillnad?

            //loop thorugh Person[] a;
            foreach (Person P in a)
            {
                //write to file
                fs.Write(Encoding.UTF8.GetBytes($"{P.GetPersonString()}\n"));
            }

            //close file
            fs.Close();
            
        }
    }
}
