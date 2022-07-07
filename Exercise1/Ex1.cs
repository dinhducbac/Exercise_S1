using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class Ex1
    {
        public string sSportCar = "";
        public Ex1()
        {
            var lstSportCar = new List<SportCar>()
            {
                new SportCar("HONDA",200,"RED"),
                new SportCar("LAMBOGINI", 250,"WHITE"),
                new SportCar("LAMBOGINI", 450,"YELLOW"),
                new SportCar("TOYOTA",180,"RED"),
                new SportCar("BUGATI",300,"BROWN")
            };
            //Task.Run(async () => await Init(lstSportCar));
            //Init(lstSportCar);
        }
        public async Task Init(List<SportCar> sportCars)
        {
            sSportCar += $"Count total: {Count(sportCars)}\n";
            sSportCar += $"Count LAMBOGINI: {Count("LAMBOGINI", sportCars)}\n";
            var timer = new Stopwatch();
            timer.Start();
            Task<string> t1 = ExampleTask();
            Task<string> t2 = ExampleTask();
            Task<string> t3 = ExampleTask();
            await Task.WhenAll(t1, t2, t3);
            sSportCar += $"Result: {t1.Result},\n\t {t2.Result}, \n\t{t3.Result}\n";
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            sSportCar += $"Time taken: {timeTaken.ToString(@"m\:ss\.fff")}\n";
            timer.Start();
            string t4 = await ExampleTask();
            string t5 = await ExampleTask();
            string t6 = await ExampleTask();
            timer.Stop();
            timeTaken = timer.Elapsed;
            sSportCar += $"Result: {t4},\n\t {t5}, \n\t{t6}\n";
            sSportCar += $"Time taken: {timeTaken.ToString(@"m\:ss\.fff")}\n";
            
        }

        public static async Task<string> ExampleTask()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://catfact.ninja");
                    using var responseMessage = await client.GetAsync("/fact");
                    var content = responseMessage.Content.ReadAsStringAsync();
                    //Console.WriteLine(content.Result.ToString());
                    //return "";
                    return content.Result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
        public int Count(List<SportCar> lstSportCar)
        {
            return lstSportCar.Count();
        }
        public int Count(string tradeMark, List<SportCar> lstSportCar)
        {
            return lstSportCar.Where(p => p.tradeMark == tradeMark).Count();
        }
        public class Car
        {
            public string tradeMark { get; set; }
            public virtual string GetColor()
            {
                return "";
            }
        }
        public class SportCar : Car
        {
            public int hoursePower { get; set; }
            private string Color { get; set; }
            public SportCar(string tradeMark, int hoursePower, string color)
            {
                this.tradeMark = tradeMark;
                this.hoursePower = hoursePower;
                this.Color = color;
            }
            public override string GetColor()
            {
                return Color;
            }
        }
    }
}
