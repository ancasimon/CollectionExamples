using CollectionExamples.LinqStuff;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace CollectionExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new Example();
            example.Run();


            //Lists are a general purpose collection that is pretty good at everything. 
            var instructors = new List<string>();
            var students = new List<string>();
            var evening11 = new List<string>();

            var numbers = new List<int>();

            instructors.Add("Jameka");
            instructors.Add("Nathan");
            instructors.Add("John");

            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(5);

            students.Add("Aaron");
            students.Add("Monique");

            //Add multiple objects at once from an existing list:
            evening11.AddRange(instructors);
            evening11.AddRange(students);

            foreach (var person in evening11)
            {
                Console.WriteLine($"{person} is in evening cohort 11.");
            }

            var isSteveInE11 = evening11.Contains("Steve");

            //ternary inside interpolated strings have to be in parentheses - otherwise, the compiler thinks you are trying to end the string - since " always refer to the beginning and end of a string.
            Console.WriteLine($"Steve is {(isSteveInE11 ? "" : "not ")}in e11."); //we wrapped the ternary inside the parentheses to put it inside the console.writeline

            //In this evening11 list, find something  that matches the following expression:
            //given a person, does that person match the following expression:
            //as soona as it finds one, it stops - so it only finds the first person in the list that matches!!
            //if there's no match. Find returns null - the default value for whatever type of generic list that is!
            var matchingPerson = evening11.Find(person => person.StartsWith("J"));

            // person.StartsWith("J") -- this is a predicate!! predicates will always return a boolean but they may take different kinds of arguments. A predicate is a boolean expression. 
            //in this case, the predicate is a string predicate. - if we were doing this on the numbers list, that woudl be an int predicate. 

            Console.WriteLine($"{matchingPerson} starts with J.");

            //in a list, the index is the key
            Console.WriteLine($"{students[1]} is the student at the index of 1.");

            //dictionaries have 2 generic type parameters. 
            var words = new Dictionary<string, string>();
            //I am declaring a variable called words that is a dictionary of string string / with string keys and string values. This is a dictionary that is keyed on strings and contains values of strings. 
            words.Add("pedantic", "Like a pedant"); //I would like to add an item to my dictionary that has a key of pedantic and this string as the value - "like a pedant"
            words.Add("scrupulous", "Diligent, thorough");
            words.Add("congratulate", "to be excited for");


            //USING LINQ with Dictionaries - when you do a lambda expression, you still need the key-value pair!!
            words.Any(word => word.Key == "pedantic");

            //YOU CSN transform a dictionary into something that isn't a dictionary > into a list for ex:
            var keys = words.Select(word => word.Key);
            var definitions = words.Select(word => word.Value);

            //keys must be unique - this won't work:
            //words.Add("Congratulate", "not a real thing");

            //to change the value of an item ina Dictionary: pull it out by its key and then set it to the new value!!
            words["congratulate"] = "stuff";

            Console.WriteLine($"The fake definition of Scrupulous is {words["scrupulous"]}");

            //foreach (var entry in words) // when you iterate over a Dictionary, you get both things - the key and the value - so you need to pull each of them - Key and Value - from the object you get back/the Key-Value pair. 
            //{
            //    Console.WriteLine($"The fake definition of {entry.Key} is {entry.Value}.");
            //}


            //This means we are destructuring the key-valuey pair into new variables that store each of those - the Key and the Value!!
            foreach (var (word,definition) in words) 
            {
                Console.WriteLine($"The fake definition of {word} is {definition}.");
            }

            var wordsWithMultipleDefinitions = new Dictionary<string, List<string>>();

            //collection initializer example in the list argument below:
            wordsWithMultipleDefinitions.Add("scrupulous", new List<string>()
            {
                "Diligent",
                "Thorough",
                "Extremely attentive to detail",
            });

            //dicitonary initializer:
            var wordsWithDefs = new Dictionary<string, List<string>>
            {
                {
                    "Scrupulous",
                    new List<string>
                    {
                        "Diligent",
                "Thorough",
                "Extremely attentive to detail",
                    }
                },
                    {
                    "word2",
                    new List<string>
                    {
                        "abc",
                        "def"
                    }
                }
            };

            foreach (var (word, definitions1) in wordsWithMultipleDefinitions)
            {
                Console.WriteLine($"{word} is defined as:");
                foreach(var definition in definitions1)
                {
                    Console.WriteLine($"    {definition}");
                }
            }

            //validate uniqueness so you don't get an exception
            if (words.ContainsKey("congratulate"))
            {
                words["congratulate"] = "new def";
            }
            else
            {
                words.Add("congratulate", "def");
            }

            //another method you can try to do the same thing: TryAdd - which is a boolean and returns false if it doesn't find the key-avlue pair provided
            //this is same as code block above - just with a different syntax
            //this says: try to add the following key-value pair - and if you cannot do that (the bang!!), then (that means the key already exists there ) then just update the definition to the string provided. 
            if (!words.TryAdd("congratulate", "new def"))
                {
                words["congratulate"] = "new def";
            }


            //Queue is FIFO - first in, first out
            var queue = new Queue<string>();
            queue.Enqueue("this is first");
            queue.Enqueue("second");
            queue.Enqueue("third");

            foreach(var item in queue)
            {
                Console.WriteLine(item);
            }

            //to drain the queue:

            var queueCount = queue.Count;

            for (var i = 0; i > queue.Count; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }

            //stack = LIFO - last in, first out - you will always pull the last one out until you get to the bottom

        }
    }
}
