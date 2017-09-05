using System;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            GarageUI garage = new GarageUI();

            garage.RunGarage();
            Console.WriteLine("Press 'enter' to exit");
            Console.ReadLine();
        }
    }
}
