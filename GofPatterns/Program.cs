using System;
using GofPatterns.Behavioral;
using GofPatterns.Creational;
using GofPatterns.Structural;

namespace GofPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creational
            //-Factory Method-
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();
            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();

            //-Abstract Factory-
            GofPatterns.Creational.Hero elf = new GofPatterns.Creational.Hero(new ElfFactory());
            elf.Hit();
            elf.Run();
            GofPatterns.Creational.Hero voin = new GofPatterns.Creational.Hero(new VoinFactory());
            voin.Hit();
            voin.Run();

            //-Singleton-
            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);

            // у нас не получится изменить ОС, так как объект уже создан    
            comp.OS = OS.getInstance("Windows 10");

            //-Prototype-
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            //-Builder-
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());
            #endregion

            #region Behavioral
            //-Strategy-
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();


            //-Observer-
            Stock stock = new Stock();
            Bank bank = new Bank("ЮнитБанк", stock);
            Broker broker = new Broker("Иван Иваныч", stock);
            // имитация торгов
            stock.Market();
            // брокер прекращает наблюдать за торгами
            broker.StopTrade();
            // имитация торгов
            stock.Market();


            //-Strategy-
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            Microwave microwave = new Microwave();
            // 5000 - время нагрева пищи
            pult.SetCommand(new MicrowaveCommand(microwave, 5000));
            pult.PressButton();


            //-Iterator-
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);


            //-State-
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();


            //-ChainOfResponsibility-
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.Successor = h2;
            h1.HandleRequest(2);


            //-Interpreter-
            Context context = new Context();
            // определяем набор переменных
            int x = 5;
            int y = 8;
            int z = 2;
            // добавляем переменные в контекст
            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);
            // создаем объект для вычисления выражения x + y - z
            IExpression expression = new SubtractExpression(
                new AddExpression(
                    new NumberExpression("x"), new NumberExpression("y")
                ),
                new NumberExpression("z")
            );
            int result = expression.Interpret(context);
            Console.WriteLine("результат: {0}", result);


            //-Mediator-
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;
            customer.Send("Есть заказ, надо сделать программу");
            programmer.Send("Программа готова, надо протестировать");
            tester.Send("Программа протестирована и готова к продаже");


            //-Memento-
            GofPatterns.Behavioral.Hero hero = new GofPatterns.Behavioral.Hero();
            hero.Shoot(); // делаем выстрел, осталось 9 патронов
            GameHistory game = new GameHistory();
            game.History.Push(hero.SaveState()); // сохраняем игру
            hero.Shoot(); //делаем выстрел, осталось 8 патронов
            hero.RestoreState(game.History.Pop());
            hero.Shoot(); //делаем выстрел, осталось 8 патронов
        

            //-Visitor-
            var structure = new Bank1();
            structure.Add(new Person { Name = "Иван Алексеев", Number = "82184931" });
            structure.Add(new Company { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445" });
            structure.Accept(new HtmlVisitor());
            structure.Accept(new XmlVisitor());
            #endregion

            #region Structural
            //-Decorator-
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost());

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost());

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost());


            //-Adapter-
            // путешественник
            Driver driver = new Driver();
            // машина
            Auto auto1 = new Auto();
            // отправляемся в путешествие
            driver.Travel(auto1);
            // встретились пески, надо использовать верблюда
            Camel camel = new Camel();
            // используем адаптер
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            // продолжаем путь по пескам пустыни
            driver.Travel(camelTransport);


            //-Facade-
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();
            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);
            Programmer programmer1 = new Programmer();
            programmer1.CreateApplication(ide);


            //-Composite-
            Component fileSystem = new Directory("Файловая система");
            // определяем новый диск
            Component diskC = new Directory("Диск С");
            // новые файлы
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");
            // добавляем файлы на диск С
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            // добавляем диск С в файловую систему
            fileSystem.Add(diskC);
            // выводим все данные
            fileSystem.Print();
            Console.WriteLine();
            // удаляем с диска С файл
            diskC.Remove(pngFile);
            // создаем новую папку
            Component docsFolder = new Directory("Мои Документы");
            // добавляем в нее файлы
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            diskC.Add(docsFolder);
            fileSystem.Print();


            //-Proxy-
            using (IBook book = new BookStoreProxy())
            {
                // читаем первую страницу
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
                // читаем вторую страницу
                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);
                // возвращаемся на первую страницу    
                page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
            }


            //-Bridge-
            // создаем нового программиста, он работает с с++
            Programmer1 freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            // пришел новый заказ, но теперь нужен c#
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();


            //-Flyweight-
            double longitude = 37.61;
            double latitude = 55.74;

            HouseFactory houseFactory = new HouseFactory();
            for (int i = 0; i < 5; i++)
            {
                House1 panelHouse = houseFactory.GetHouse("Panel");
                if (panelHouse != null)
                    panelHouse.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }

            for (int i = 0; i < 5; i++)
            {
                House1 brickHouse = houseFactory.GetHouse("Brick");
                if (brickHouse != null)
                    brickHouse.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }
            #endregion
        }
    }
}