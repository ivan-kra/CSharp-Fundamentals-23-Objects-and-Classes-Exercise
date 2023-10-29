using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public string ID { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Person> people = new Dictionary<string, Person>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();
            string name = data[0];
            string id = data[1];
            int age = int.Parse(data[2]);

            if (people.ContainsKey(id))
            {
                people[id].Name = name;
                people[id].Age = age;
            }
            else
            {
                Person person = new Person
                {
                    Name = name,
                    ID = id,
                    Age = age
                };
                people[id] = person;
            }
        }

        List<Person> sortedPeople = people.Values.OrderBy(p => p.Age).ToList();

        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
        }
    }
}