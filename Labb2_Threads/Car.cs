// Stina Hedman
// Net23

using System;
using System.Threading.Tasks;

namespace Labb2_Threads
{
    class Car
    {

        public string Name { get; }
        public int Speed { get; set; }

        public double DistanceTraveled { get; set; }

        public Car(string name)
        {
            Name = name;
            Speed = 0;
            DistanceTraveled = 0;
        }

        //Metod for racing
        public async Task<Car> RaceAsync(int raceDistance)
        {
            int counter = 0;
            int waitTime = 0;
            Speed = 120;
            Console.WriteLine($"{Name} is off!");

            //while distance traveled is less than the complete lenght of the course
            while (DistanceTraveled < raceDistance)
            {
                //add distance traveled for each second
                await Task.Delay(1000);
                counter++;
                DistanceTraveled += Speed / 3.6;

                //if 30 sec has passed, call for a random Event
                if (counter == 10)
                {
                    waitTime = RandomEvent();

                    if (waitTime > 0)
                    {
                        await Task.Delay(waitTime);
                    }
                    counter = 0;
                }
            }

            Console.WriteLine($"{Name} reached the finnishline!");
            return this;
        }

        //Method for random event
        public int RandomEvent()
        {
            
            Random random = new Random();
            int rndNr = random.Next(1, 50);

            //out of gas
            if (rndNr == 1)
            {
                Console.WriteLine($"{Name} is out of gas, needs to stop to refuel.");
                return 30000;
            }

            //Punctured wheel
            else if (rndNr > 1 && rndNr < 4)
            {
                Console.WriteLine($"{Name} got a flat tire.. changing tire.");
                return 20000;
            }

            //Bird on the windshield
            else if (rndNr > 3 && rndNr < 9)
            {
                Console.WriteLine($"{Name} got a bird on the windshield.");
                return 10000;
            }

            //Engine trouble
            else if (rndNr > 8 && rndNr < 18)
            {
                Console.WriteLine($"{Name} got sudden engine troubles and is loosing speed.");
                Speed -= 1;
                return 0;
            }

            else
            {
                return 0;
            }
        }
    }
}
