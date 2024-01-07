// Stina Hedman
// Net23

using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Labb2_Threads
{
    internal class Program
    { 
        static async Task Main(string[] args)
        {
            //Distance of the race in meters and set maxspeed
            int raceDistance = 10000;
            string input = "";
            Car inTheLead;
            bool racing = true;
            bool raceStarted = false;

            //Create two cars for the race.
            Car car1 = new Car("Tina Turner");
            Car car2 = new Car("Britney Stears");

            Console.WriteLine("Cars standing by!");
            Console.WriteLine("Press any key to start the race! Press enter to get a status update during the race.");
            Console.ReadKey();


            //Start start the races
            Task<Car>[] tasks = {car1.RaceAsync(raceDistance), car2.RaceAsync(raceDistance) };

            //Start racetracker
            RaceTracker tracker = new RaceTracker();
            tracker.RaceStatus(new List<Car> { car1, car2 }, raceDistance);

            //await the first completed task                 
            Task<Car> firstCompleted = await Task.WhenAny(tasks);
      

            //take the result from the first completed task
            Car result = await firstCompleted;

            //print the winner
            Console.WriteLine($"\n{result.Name} finished first!\n");

        }

    }
}