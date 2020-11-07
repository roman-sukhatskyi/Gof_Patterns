using System;
using System.Collections.Generic;
using System.Text;

namespace GofPatterns.Structural
{
    interface ITransport
    {
        void Drive();
    }
    // класс машины
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    // интерфейс животного
    interface IAnimal
    {
        void Move();
    }
    // класс верблюда
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Верблюд идет по пескам пустыни");
        }
    }
    // Адаптер от Camel к ITransport
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public void Drive()
        {
            camel.Move();
        }
    }
}
