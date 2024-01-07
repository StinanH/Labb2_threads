// Stina Hedman
// NET23

namespace Labb2_Threads
{
    internal class RaceTracker
    {
        //Method for checking race status
        public async Task<RaceTracker> RaceStatus(List<Car> cars, int raceDistance)
        {
            //while the cars haven't reached the finnishline
            while (cars.Any(c => c.DistanceTraveled < raceDistance))
            {
                await Task.Delay(1000);

                
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        //if user is pressing enter
                        case ConsoleKey.Enter:

                            //print status of each car.
                            foreach (Car c in cars)
                            {
                                Console.WriteLine($"{c.Name} has traveled {(int)c.DistanceTraveled} at {c.Speed} km/h.");
                            }
                            break;
                    }
                }
            }
            return this;
        }
    }
}
