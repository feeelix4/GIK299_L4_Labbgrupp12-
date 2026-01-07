
using System;
using System.Collections.Generic;

namespace Labb_4
{
    enum Gender
    {
        Kvinna,
        Man,
        IckeBinar,
        Annan
    }

    struct Hair
    {
        public string Color;
        public string Length;
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Hair Hair { get; set; }
        public DateTime BirthDate { get; set; }
        public string EyeColor { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}\n" +
                   $"Kön: {Gender}\n" +
                   $"Född: {BirthDate:yyyy-MM-dd}\n" +
                   $"Ögonfärg: {EyeColor}\n" +
                   $"Hår: {Hair.Color}, {Hair.Length}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== MENY ===");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Lista personer");
                Console.WriteLine("3. Avsluta");
                Console.Write("Val: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPerson(persons);
                        break;
                    case "2":
                        ListPersons(persons);
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Felaktigt val.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddPerson(List<Person> persons)
        {
            Console.Clear();
            Console.WriteLine("=== LÄGG TILL PERSON ===\n");

            try
            {
                Console.Write("Förnamn: ");
                string firstName = Console.ReadLine();

                Console.Write("Efternamn: ");
                string lastName = Console.ReadLine();

                Gender gender;
                while (true)
                {
                    Console.Write("Kön (Kvinna/Man/IckeBinar/Annan): ");
                    if (Enum.TryParse(Console.ReadLine(), true, out gender))
                        break;

                    Console.WriteLine("Felaktigt kön, försök igen.");
                }

                Console.Write("Hårfärg: ");
                string hairColor = Console.ReadLine();

                Console.Write("Hårlängd: ");
                string hairLength = Console.ReadLine();

                Console.Write("Ögonfärg: ");
                string eyeColor = Console.ReadLine();

                DateTime birthDate;
                while (true)
                {
                    Console.Write("Födelsedatum (ÅÅÅÅ-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                        break;

                    Console.WriteLine("Felaktigt datumformat.");
                }

                persons.Add(new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    EyeColor = eyeColor,
                    BirthDate = birthDate,
                    Hair = new Hair { Color = hairColor, Length = hairLength }
                });

                Console.WriteLine("\n Personen har lagts till!");
            }
            catch
            {
                Console.WriteLine("Ett oväntat fel uppstod.");
            }

            Console.WriteLine("\nTryck Enter för att återgå till menyn...");
            Console.ReadLine();
        }

        static void ListPersons(List<Person> persons)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA PERSONER ===\n");

            if (persons.Count == 0)
            {
                Console.WriteLine("Inga personer i listan.");
            }
            else
            {
                foreach (Person p in persons)
                {
                    Console.WriteLine(p);
                    Console.WriteLine("------------------------");
                }
            }

            Console.WriteLine("\nTryck Enter för att gå tillbaka...");
            Console.ReadLine();
        }
    }
}