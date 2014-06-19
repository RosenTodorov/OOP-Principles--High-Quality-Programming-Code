using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are Animals.
   All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. 
   All animals are described by age, name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
   Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).*/

namespace Animals
{
    class Program
    {
        static void Main()
        {
            Kitten kitty = new Kitten("Pufi", 1); 
            Tomcat tomas = new Tomcat("Marko", 2);
            Dog sharo = new Dog("Kir4o", 3, SexEnum.male); 
            Frog squeek = new Frog("Kimi", 1, SexEnum.female); 
            kitty.MakeSomeNoise(); 
            tomas.MakeSomeNoise(); 
            sharo.MakeSomeNoise(); 
            squeek.MakeSomeNoise();
            
            Console.WriteLine(tomas.Gender); 
            Console.WriteLine(kitty.Gender); 

            Animal[] animals = 
            { 
                new Kitten("Koti", 2), 
                new Tomcat("Rocky", 4), 
                new Dog("Alex", 5, SexEnum.female), 
                new Frog("Siti", 2, SexEnum.female), 
                new Kitten("Kara", 6), 
                new Tomcat("Suzana", 2), 
                new Dog("Porsche", 7, SexEnum.female),
                new Frog("Kara", 10, SexEnum.female),
                new Kitten("Tonchi", 8), 
                new Tomcat("Jony", 8), 
                new Dog("Elma", 9, SexEnum.female), 
                new Frog("Liki", 5, SexEnum.female), 
            };

            var ordered = animals.GroupBy(x => x.GetType()); 
            Console.WriteLine(); 
            foreach (var animal in ordered) 
            { 
                Console.WriteLine("Average age of {0} is {1:F2}.", animal.Key.Name, animal.Average(x => x.Age));
            }
        }
    }
}