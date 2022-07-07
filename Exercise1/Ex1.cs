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
        public List<SportCar> listSportCar;
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
            Init(lstSportCar);
        }
        public async void Init(List<SportCar> sportCars)
        {
            var lst = await GetStrongerSportCar(sportCars);
            sSportCar += $"Count total: {Count(sportCars)}\n";
            sSportCar += $"Count LAMBOGINI: {Count("LAMBOGINI",sportCars)}\n";
            sSportCar += "Sport car has hourse power >= 200\n";
            foreach (var o in lst)
            {
                sSportCar += $"TRADEMARK: {o.tradeMark}, HOURSEPOWER: {o.hoursePower}, COLOR: {o.GetColor()}\n";
            }
        } 
        public async Task<List<SportCar>> GetStrongerSportCar(List<SportCar> lstSportCar)
        {
            return (from l in lstSportCar
                    where l.hoursePower >= 200
                    select l).ToList();
        }
        public int Count(List<SportCar> lstSportCar)
        {
            return lstSportCar.Count();
        }
        public int Count(string tradeMark, List<SportCar> lstSportCar)
        {
            return lstSportCar.Where(p=>p.tradeMark == tradeMark).Count();
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
            public SportCar(string tradeMark,int hoursePower,string color)
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
