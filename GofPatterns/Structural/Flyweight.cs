using System;
using System.Collections.Generic;

namespace GofPatterns.Structural
{
    abstract class House1
    {
        protected int stages; // количество этажей

        public abstract void Build(double longitude, double latitude);
    }

    class PanelHouse : House1
    {
        public PanelHouse()
        {
            stages = 16;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Построен панельный дом из 16 этажей; координаты: {0} широты и {1} долготы",
                latitude, longitude);
        }
    }
    class BrickHouse : House1
    {
        public BrickHouse()
        {
            stages = 5;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Построен кирпичный дом из 5 этажей; координаты: {0} широты и {1} долготы",
                latitude, longitude);
        }
    }

    class HouseFactory
    {
        Dictionary<string, House1> houses = new Dictionary<string, House1>();
        public HouseFactory()
        {
            houses.Add("Panel", new PanelHouse());
            houses.Add("Brick", new BrickHouse());
        }

        public House1 GetHouse(string key)
        {
            if (houses.ContainsKey(key))
                return houses[key];
            else
                return null;
        }
    }
}
