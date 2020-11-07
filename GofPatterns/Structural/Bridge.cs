using System;

namespace GofPatterns.Structural
{

    interface ILanguage
    {
        void Build();
        void Execute();
    }

    class CPPLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("С помощью компилятора C++ компилируем программу в бинарный код");
        }

        public void Execute()
        {
            Console.WriteLine("Запускаем исполняемый файл программы");
        }
    }

    class CSharpLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("С помощью компилятора Roslyn компилируем исходный код в файл exe");
        }

        public void Execute()
        {
            Console.WriteLine("JIT компилирует программу бинарный код");
            Console.WriteLine("CLR выполняет скомпилированный бинарный код");
        }
    }

    abstract class Programmer1
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }
        public Programmer1(ILanguage lang)
        {
            language = lang;
        }
        public virtual void DoWork()
        {
            language.Build();
            language.Execute();
        }
        public abstract void EarnMoney();
    }

    class FreelanceProgrammer : Programmer1
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("Получаем оплату за выполненный заказ");
        }
    }
    class CorporateProgrammer : Programmer1
    {
        public CorporateProgrammer(ILanguage lang)
            : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("Получаем в конце месяца зарплату");
        }
    }
}
