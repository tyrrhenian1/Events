using System;
using System.Collections.Generic;
using System.Text;

namespace Events2
{
    public delegate void FireEvent(int day, int building);
    class TownWithEvents
    {
        string townName;
        int buildings;
        int days;
        double fireProbability;
        Random random = new Random();
        public event FireEvent fireEvent;
        void OnFire(int day, int buildings)
        {
            if (fireEvent != null) fireEvent(day, buildings);
        }
        public TownWithEvents(string name,int buildings,int days,double fireProbability)
        {
            townName = name;
            this.buildings = buildings;
            this.days = days;
            this.fireProbability = fireProbability;
        }
        public string TownName { get { return townName; } }
        public void TownLife()
        {
            const string OK = "В городе все спокойно! Пожаров не было.";
            bool wasFire = false;
            for(int day = 1;day<days;day++)
                for(int building = 1;building<buildings;building++)
                    if (random.NextDouble() < fireProbability)
                    {
                        OnFire(day, building);
                        wasFire = true;
                    }
            if (!wasFire)
                Console.WriteLine(OK);
        }
    }
}
