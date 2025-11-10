using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace Question_3
{
    
    public class Drone
    {
        private static Random rand = new Random();
public int Id { get;  }
public double DistanceCovered { get; private set; }
        public bool Finished=> DistanceCovered > 25;
        public Drone(int ID)
        {
            Id = ID;
            DistanceCovered = 0;
        }
        public void Move()
        {
            double distance = rand.NextDouble() * 10;
            DistanceCovered += distance;
            Console.WriteLine($"Drone {Id} covered: {Math.Round(DistanceCovered)} km");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Drone> drones = new List<Drone>();
            for (int i = 0; i < 5; i++)
            {
                drones.Add(new Drone(i));
            }
            Random rng = new Random();
            Drone winner = null;
            int finishedCount = 0;
            int RoundCount = 1;
            Console.WriteLine("🏁 Drone Race Begins!\n");
            while (finishedCount < drones.Count)
            {
                Console.WriteLine($"========== Round {RoundCount} ==========");
                RoundCount++;
                List<Drone> shuffled = drones.OrderBy(_ => rng.Next()).ToList();
                foreach (var drone in shuffled)
                {
                    if (drone.Finished) continue;

                    drone.Move();
                    if (drone.Finished)
                    {
                        finishedCount++;
                        if (winner == null)
                        {
                            winner = drone;
                        }
                        Thread.Sleep(400);
                    }
                    Thread.Sleep(1000);
                }
            }
                Console.WriteLine($"\n🎉 All drones have finished!");
                Console.WriteLine($"🏆 Winner: Drone {winner.Id}");
        }
    }
}
