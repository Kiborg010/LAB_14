using ClassLibrary1;
using LAB_12_4;

public class Requests
{
    static string line = new string('-', 25);
    public static Queue<List<Car>> CreateFactory(int countCars = 3, int countPassngerCars = 3, int countOffRoadCars = 3, int countLorryCars = 3)
    {
        Queue<List<Car>> factory = new Queue<List<Car>>();
        List<Car> cars = CreateCars(countCars, 0);
        List<Car> passengerCars = CreateCars(countPassngerCars, 2);
        List<Car> offRoadCars = CreateCars(countOffRoadCars, 3);
        List<Car> lorryCars = CreateCars(countLorryCars, 1);

        factory.Enqueue(cars);
        factory.Enqueue(passengerCars);
        factory.Enqueue(offRoadCars);
        factory.Enqueue(lorryCars);

        return factory;
    }

    public static List<Car> CreateCars(int size, int type)
    {
        List<Car> result = new List<Car>();
        for (int i = 0; i < size; i++)
        {
            result.Add(CreateCarWithRandomData(type));
        }
        return result;
    }

    public static MyCollection<Car> CreateCars(int count1 = 3, int count2 = 3, int count3 = 3, int count4 = 3)
    {
        MyCollection<Car> result = new MyCollection<Car>();
        for (int i = 0; i < count1; i++)
        {
            result.Add(CreateCarWithRandomData(0));
        }
        for (int i = 0; i < count2; i++)
        {
            result.Add(CreateCarWithRandomData(1));
        }
        for (int i = 0; i < count3; i++)
        {
            result.Add(CreateCarWithRandomData(2));
        }
        for (int i = 0; i < count4; i++)
        {
            result.Add(CreateCarWithRandomData(3));
        }
        return result;
    }

    static Car CreateCarWithRandomData(int type) //Функция для создания машины случайного типа со случайнми параметрами
    {
        if (type == 0) //В зависимости от числа выибраем тип
        {
            Car car = new Car(); //Создаём машину нужного типа
            car.RandomInit(); //Заполняем случайными значениями
            return car;
        }
        else if (type == 1) //В зависимости от типа создаём определённую машину
        {
            LorryCar car = new LorryCar();
            car.RandomInit();
            return car;
        }
        else if (type == 2)
        {
            PassengerCar car = new PassengerCar();
            car.RandomInit();
            return car;
        }
        else if (type == 3)
        {
            OffRoadCar car = new OffRoadCar();
            car.RandomInit();
            return car;
        }
        return null; //Заглушка (не должна произойти)
    }

    public static void PrintFactory(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пуста");
        }
        else
        {
            foreach (var cars in factory)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(line);
                    Console.WriteLine(car.ToString());
                    Console.WriteLine(line);
                }
            }
        }
    }

    public static void RequestWhereLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = from ceh in factory
                      from car in ceh
                      where car is OffRoadCar && ((OffRoadCar)car).Awd == true
                      select car;
            PrintRequestWhere(res);
        }
    }

    public static void RequestWhereEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = factory.SelectMany(ceh => ceh).Where(car => car is OffRoadCar && ((OffRoadCar)car).Awd == true);
            PrintRequestWhere(res);
        }
    }

    public static void PrintRequestWhere(IEnumerable<Car> res)
    {
        if (res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет таких внедорожников");
        }
        else
        {
            Console.WriteLine("Внедорожники с полным приводом: ");
            foreach (var item in res)
            {
                Console.WriteLine(line);
                Console.WriteLine(item.ToString());
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }

    public static void RequestUnionLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res1 = from ceh in factory
                       from car in ceh
                       where car is OffRoadCar
                       select car;
            var res2 = from ceh in factory
                       from car in ceh
                       where car is LorryCar
                       select car;
            PrintRequestUnion(res1.Union(res2));
        }
    }

    public static void RequestUnionEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res1 = factory.SelectMany(ceh => ceh).Where(car => car is OffRoadCar);
            var res2 = factory.SelectMany(ceh => ceh).Where(car => car is LorryCar);
            PrintRequestUnion(res1.Union(res2));
        }
    }

    public static void PrintRequestUnion(IEnumerable<Car> res)
    {
        if (res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет таких машин");
        }
        else
        {
            Console.WriteLine("Внедорожники и грузовики: ");
            foreach (var item in res)
            {
                Console.WriteLine(line);
                Console.WriteLine(item.ToString());
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }

    public static void RequestSumLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = (from ceh in factory
                       from car in ceh
                       where (car is not OffRoadCar) && (car is PassengerCar)
                       select ((PassengerCar)car).CountSeats).Sum();
            PrintRequestSum(res);
        }
    }

    public static void RequestSumEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = factory.SelectMany(ceh => ceh).Where(car => ((car is not OffRoadCar) && (car is PassengerCar))).Select(car => ((PassengerCar)car).CountSeats).Sum();
            PrintRequestSum(res);
        }
    }

    public static void PrintRequestSum(int res)
    {
        if (res == 0)
        {
            Console.WriteLine("В коллекции нет таких машин");
        }
        else
        {
            Console.WriteLine($"Количество сидений у легковых автомобилей, не считая внедорожников: {res}");
        }
    }

    public static void RequestGroupLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = from ceh in factory
                      from car in ceh
                      group car by car.Brend;
            PrintRequestGroup(res);
        }
    }

    public static void RequestGroupEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = factory.SelectMany(ceh => ceh).GroupBy(car => car.Brend);
            PrintRequestGroup(res);
        }
    }

    public static void PrintRequestGroup(IEnumerable<IGrouping<string, Car>> res)
    {
        if (res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет таких машин");
        }
        else
        {
            foreach (var item in res)
            {
                foreach (var car in item)
                {
                    Console.WriteLine(line);
                    Console.WriteLine(car.ToString());
                    Console.WriteLine(line);
                }
            }
        }
    }

    public static void RequestLetLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = from ceh in factory
                      from car in ceh
                      let newCost = (int)(car.Cost * 0.9)
                      select new { Brend = car.Brend, NewCost = newCost };
            PrintRequestLet(res);
        }
    }

    public static void RequestLetEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = factory.SelectMany(ceh => ceh).
                Select(car =>
                {
                    int newCost = (int)(car.Cost * 0.9);
                    return new { Brend = car.Brend, NewCost = newCost };
                });
            PrintRequestLet(res);
        }
    }

    public static void PrintRequestLet(IEnumerable<dynamic> res)
    {
        if (res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет таких машин");
        }
        else
        {
            foreach (var item in res)
            {
                Console.WriteLine(line);
                Console.WriteLine($"Бренд: {item.Brend}, новая цена: {item.NewCost}");
                Console.WriteLine(line);
            }
        }
    }

    public static void RequestWhereLINQTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = from car in collection
                      where car is OffRoadCar && ((OffRoadCar)car).Awd == true
                      select car;
            PrintRequestWhereTwo(res);
        }
    }

    public static void RequestWhereExTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = collection.Where(car => car is OffRoadCar && ((OffRoadCar)car).Awd == true);
            PrintRequestWhereTwo(res);
        }
    }

    public static void PrintRequestWhereTwo(IEnumerable<Car> res)
    {
        if (res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет таких внедорожников");
        }
        else
        {
            Console.WriteLine("Внедорожники с полным приводом: ");
            foreach (var item in res)
            {
                Console.WriteLine(line);
                Console.WriteLine(item.ToString());
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }

    public static void RequestUnionLINQTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res1 = from car in collection
                       where car is OffRoadCar
                       select car;
            var res2 = from car in collection
                       where car is LorryCar
                       select car;
            PrintRequestUnionTwo(res1.Union(res2));
        }
    }

    public static void RequestUnionExTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res1 = collection.Where(car => car is OffRoadCar);
            var res2 = collection.Where(car => car is LorryCar);
            PrintRequestUnionTwo(res1.Union(res2));
        }
    }

    public static void PrintRequestUnionTwo(IEnumerable<Car> res)
    {
        if (res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет таких машин");
        }
        else
        {
            Console.WriteLine("Внедорожники и грузовики: ");
            foreach (var item in res)
            {
                Console.WriteLine(line);
                Console.WriteLine(item.ToString());
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }

    public static void RequestSumLINQTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = (from car in collection
                       where (car is not OffRoadCar) && (car is PassengerCar)
                       select ((PassengerCar)car).CountSeats).Sum();
            PrintRequestSumTwo(res);
        }
    }

    public static void RequestSumExTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = collection.Where(car => ((car is not OffRoadCar) && (car is PassengerCar))).Select(car => ((PassengerCar)car).CountSeats).Sum();
            PrintRequestSumTwo(res);
        }
    }

    public static void PrintRequestSumTwo(int res)
    {
        if (res == 0)
        {
            Console.WriteLine("В коллекции нет таких машин");
        }
        else
        {
            Console.WriteLine($"Количество сидений у легковых автомобилей, не считая внедорожников: {res}");
        }
    }

    public static void RequestGroupLINQTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = from car in collection
                      where car is not null
                      group car by car.Brend;
            PrintRequestGroupTwo(res);
        }
    }

    public static void RequestGroupExTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Коллекция пустая");
        }
        else
        {
            var res = collection.Where(car => car is not null).GroupBy(car => car.Brend);
            PrintRequestGroupTwo(res);
        }
    }

    public static void PrintRequestGroupTwo(IEnumerable<IGrouping<string, Car>> res)
    {
        if (res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет таких машин");
        }
        else
        {
            foreach (var item in res)
            {
                foreach (var car in item)
                {
                    Console.WriteLine(line);
                    Console.WriteLine(car.ToString());
                    Console.WriteLine(line);
                }
            }
        }
    }
}