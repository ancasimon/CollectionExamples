using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.Json;

namespace CollectionExamples.LinqStuff
{
    class Example
    {
        public void Run()
        {
            var animals = new List<string> { "Dog", "Cat", "Elephant", "Goat" };
            Console.WriteLine(string.Join(",", animals));

            //modifying the data in the collection and creating a new collection with the modified data!!
            //the lambda / fat arrow function creates a new Animal class and also passes in an initializer for those new objects:
            //selects are like map, for transformation
            var realAnimals = animals.Select(animal => new Animal { Name = animal, Color = "brown" });

            //the JSon serializer allows us to print it and have it look like the Javascript objects - we will store this in a new object and we will porint that object to the console:
            var jsonAnimals = JsonSerializer.Serialize(realAnimals, new JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine(jsonAnimals);
            //Where is like filter:
            var filteredAnimals = realAnimals.Where(animal => animal.Name.Contains('a'));

            var filteredAnimals2 = realAnimals.Where(animal => animal.Name == "Cat");

            //chaining Select() and Where() methods together:
            //because each Linq method returns a collection, they are able to be chained:
            var chainedResults = animals
                .Select(animal => new Animal { Name = animal, Color = "Brown" })
                .Where(animal => animal.Name.Contains('a'));

            //are there animals with the letter z?
            //var anyAnimalsWithZ = animals.Where(animal => animal.Contains('z')).Count() > 0;
            //a better way to do the above - with Any()  which stops as soon as it finds an item that meets its condition:

            var anyAnimalsWithZ = animals.Any(Animal => Animal.Contains('z'));

            //if I just want to find the first thing that meets a condition:
            //assumption: that there is at least one thing that matches!
            //if we call .First() on a collection and there's not a match, then it will throw an exception!
            var firstAnimalWithA = realAnimals.First(animal => animal.Name.Contains('a')); //this returns a string
            //returns the first item that matches or the default value of the collection type if no match:
            var firstAnimalWithZ = realAnimals.FirstOrDefault(animal => animal.Name.Contains('z'));

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 3, 6, 4, 5, 11, 67 };

            //order - ascending by default (OrderByDescending is the alternative) - and if you want to order by the number, then it's just number:
            var orderedNumbers = numbers.OrderBy(number => number);

            var orderedANimals = realAnimals.OrderBy(animal => animal.Name);

            //find the highest number:
            var biggestNumber = numbers.Max();


            //you cna also use the .Max() method on strings:
            //if I want to fidn the animal with the longest name - the following code will return the actual length!!
            var animalsWithLongestName = realAnimals.Max(animal => animal.Name.Length);

            //gives you an array of the distinct numbers:
            //var uniqueNumbers = numbers.Distinct();

            //to actually run the list right away / execute code imemdiately!! Otherwise, it is deferred execution and that new list doesn't get generated until someone calls it. 
            var uniqueNumbers = numbers.Distinct().ToList();

            var animalsToGroup = new List<Animal>
            {
                new Animal {Name = "Steve", Color = "blue", Type = "bird"},
                new Animal {Name = "John", Color = "red", Type = "bird"},
                new Animal {Name = "Sally", Color = "yellow", Type = "bird"},
                new Animal {Name = "Jim", Color = "brow", Type = "monkey"},
                new Animal {Name = "Nancy", Color = "white", Type = "bird"},
                new Animal {Name = "Joey", Color = "white", Type = "kangaroo"},
            };

            var groupedAnimals = animalsToGroup.GroupBy(animal => animal.Type);

            foreach(var group in groupedAnimals)
            {
                Console.WriteLine($"Animal type is {group.Key}");
                foreach(var animal in group)
                {
                    Console.WriteLine($"{animal.Name} is a {animal.Color} {animal.Type}.");

                }
            }

            


        }
    }
}
