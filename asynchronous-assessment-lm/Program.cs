using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

/**
 * INSTRUCTIONS:
 *  1. Modify the codes below and make it asynchronous
 *  2. After your modification, explain what makes it asynchronous
**/


namespace asynchronous_assessment_lm
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var taskList = new List<Task>();

            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            taskList.Add(Task.Run(() => FryEggs(2)));
            taskList.Add(Task.Run(() => FryBacon(3)));
            taskList.Add(Task.Run(() => ToastBreadAndPutButterAndJam(2)));

            await Task.WhenAll(taskList);
            Console.WriteLine("Eggs are ready");
            Console.WriteLine("Bacon is ready");
            Console.WriteLine("toast is ready");

            Juice orange = PourOJ();
            Console.WriteLine("Orange juice is ready");
            Console.WriteLine("Breakfast is ready!");

            Console.ReadLine();
        }

        private static async Task ToastBreadAndPutButterAndJam(int slices)
        {
            Toast toast = await ToastBread(slices);

            ApplyButter(toast);
            ApplyJam(toast);
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBread(int slices)
        {
            Parallel.For(0, slices, i =>
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            });

            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);

            Parallel.For(0, slices, i =>
            {
                Console.WriteLine("flipping a slice of bacon");
            });

            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);

            return new Bacon();
        }

        private static async Task<Egg> FryEggs(int count)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {count} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private class Coffee
        {
        }

        private class Egg
        {
        }

        private class Bacon
        {
        }

        private class Toast
        {
        }

        private class Juice
        {
        }
    }
}
