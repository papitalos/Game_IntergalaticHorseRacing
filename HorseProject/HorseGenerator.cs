using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HorseStats
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var horses = new List<Horse>();

            // List of possible first and last names for the horses
            var firstNames = new List<string> { "Thunder", "Lightning", "Shadow", "Storm", "Echo" };
            var lastNames = new List<string> { "Runner", "Charger", "Hoof", "Mane", "Tail" };

            for (float i = 0; i < 10; i++)
            {
                // Generate random stats for each horse
                var age = random.Next(1, 8);
                var stamina = random.Next(700, 1000);
                var mass = random.Next(500, 1000);
                float acceleration = random.Next((int) 0.40, (int) 0.5);
                var topSpeed = random.Next(13, 16);

                // Choose a random first and last name for the horse
                var firstName = firstNames[random.Next(firstNames.Count)];
                var lastName = lastNames[random.Next(lastNames.Count)];

                // Create a new Horse object with the random stats and name
                var horse = new Horse(age, stamina, mass, acceleration, topSpeed, firstName, lastName);

                // If the horse is between the ages of 2 and 4, increase its stamina, acceleration, and top speed by 15%
                if (horse.Age >= 2 && horse.Age <= 4)
                {
                    horse.IncreaseStats();
                }

                // Add the horse to the list of horses
                horses.Add(horse);
            }

            // Print out the stats for each horse
            foreach (var horse in horses)
            {
                Console.WriteLine(horse);
            }
        }
    }

    class Horse
    {
        public int Age { get; set; }
        public int Stamina { get; set; }
        public int Mass { get; set; }
        public float Acceleration { get; set; }
        public int TopSpeed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Horse(int age, int stamina, int mass, float acceleration, int topSpeed, string firstName, string lastName)
        {
            Age = age;
            Stamina = stamina;
            Mass = mass;
            Acceleration = acceleration;
            TopSpeed = topSpeed;
            FirstName = firstName;
            LastName = lastName;
        }

        // Increase the horse's stamina, acceleration, and top speed by 15%
        public void IncreaseStats()
        {
            Stamina += (int)(Stamina * 0.15);
            Acceleration += (int)(Acceleration * 0.15);
            TopSpeed += (int)(TopSpeed * 0.15);
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}, Stamina: {Stamina}, Mass: {Mass}, Acceleration: {Acceleration}, Top Speed: {TopSpeed}";
        }
    }
}