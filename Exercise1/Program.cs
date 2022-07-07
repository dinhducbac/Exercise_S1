using System;
using System.Collections.Generic;
using static Exercise1.Ex1;

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise1.Ex1 ex1 = new Exercise1.Ex1();
            ex1.Init(new List<SportCar>()
            {
                new SportCar("HONDA",200,"RED"),
                new SportCar("LAMBOGINI", 250,"WHITE"),
                new SportCar("LAMBOGINI", 450,"YELLOW"),
                new SportCar("TOYOTA",180,"RED"),
                new SportCar("BUGATI",300,"BROWN")
            }).Wait();
            Console.WriteLine(ex1.sSportCar);
        }
    }
}
