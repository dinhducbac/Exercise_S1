using System;
using System.Collections.Generic;
using System.Linq;
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
                new SportCar() { tradeMark = "HONDA", hoursePower = 200},
                new SportCar() { tradeMark = "LAMBOGINI", hoursePower = 250},
                new SportCar() { tradeMark = "TOYOTA", hoursePower = 180},
                new SportCar() { tradeMark = "BUGATI", hoursePower = 300}
            };
            Init(lstSportCar);
        }
        public async void Init(List<SportCar> sportCars)
        {
            var lst = await GetStrongerSportCar(sportCars);
            foreach (var o in lst)
            {
                sSportCar += $"TRADEMARK: {o.tradeMark}, HOURSEPOWER: {o.hoursePower}\n";
            }
        } 
        public async Task<List<SportCar>> GetStrongerSportCar(List<SportCar> lstSportCar)
        {
            return (from l in lstSportCar
                    where l.hoursePower >= 200
                    select l).ToList();
        }
        public class Car
        {
            public string tradeMark { get; set; }
            public virtual void Get()
            {

            }
        }
        public class SportCar : Car
        {
            public int hoursePower { get; set; }
            public override void Get()
            {
                
            }
        }
    }
}
