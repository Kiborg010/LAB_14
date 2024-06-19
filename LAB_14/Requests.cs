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

    public static IEnumerable<Car> RequestWhereLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return null;
        }
        else
        {
            var res = from ceh in factory
                      from car in ceh
                      where car is OffRoadCar && ((OffRoadCar)car).Awd == true
                      select car;
            return res;
        }
    }

    public static IEnumerable<Car> RequestWhereEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return null;
        }
        else
        {
            var res = factory.SelectMany(ceh => ceh).Where(car => car is OffRoadCar && ((OffRoadCar)car).Awd == true);
            return res;
        }
    }

    public static void PrintRequestWhere(IEnumerable<Car> res)
    {
        if (res is null || res.Count() == 0)
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

    public static IEnumerable<Car> RequestUnionLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return null;
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
            return res1.Union(res2);
        }
    }

    public static IEnumerable<Car> RequestUnionEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return null;
        }
        else
        {
            var res1 = factory.SelectMany(ceh => ceh).Where(car => car is OffRoadCar);
            var res2 = factory.SelectMany(ceh => ceh).Where(car => car is LorryCar);
            return res1.Union(res2);
        }
    }

    public static void PrintRequestUnion(IEnumerable<Car> res)
    {
        if (res is null || res.Count() == 0)
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

    public static int RequestSumLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return 0;
        }
        else
        {
            var res = (from ceh in factory
                       from car in ceh
                       where (car is not OffRoadCar) && (car is PassengerCar)
                       select ((PassengerCar)car).CountSeats).Sum();
            return res;
        }
    }

    public static int RequestSumEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return 0;
        }
        else
        {
            var res = factory.SelectMany(ceh => ceh).Where(car => ((car is not OffRoadCar) && (car is PassengerCar))).Select(car => ((PassengerCar)car).CountSeats).Sum();
            return res;
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

    public static IEnumerable<IGrouping<string, Car>> RequestGroupLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return null;
        }
        else
        {
            var res = from ceh in factory
                      from car in ceh
                      group car by car.Brend;
            return res;
        }
    }

    public static IEnumerable<IGrouping<string, Car>> RequestGroupEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return null;
        }
        else
        {
            var res = factory.SelectMany(ceh => ceh).GroupBy(car => car.Brend);
            return res;
        }
    }

    public static void PrintRequestGroup(IEnumerable<IGrouping<string, Car>> res)
    {
        if (res is null || res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет машин для группировки");
        }
        else
        {
            foreach (var item in res)
            {
                Console.WriteLine($"\n\nБренд группы: {item.Key}");
                Console.WriteLine($"Количество машин в группе: {item.Count()}");
                foreach (var car in item)
                {
                    Console.WriteLine(line);
                    Console.WriteLine(car.ToString());
                    Console.WriteLine(line);
                }
            }
        }
    }

    public static IEnumerable<dynamic> RequestJoinLINQ(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return null;
        }
        List<Company> companies = new List<Company>();
        Company company1 = new Company("Ford", 1920, "США", "Детройт");
        Company company2 = new Company("Volvo", 1927, "Швеция", "Гетеборг");
        Company company3 = new Company("Honda", 1948, "Япония", "Хамамацу");
        Company company4 = new Company("Volkswagen", 1938, "Германия", "Вольфсбург");
        Company company5 = new Company("Nissan", 1934, "Япония", "Йокогама");
        Company company6 = new Company("BMW", 1922, "Германия", "Мюнхен");
        Company company7 = new Company("Lada", 1966, "Россия", "Тольятти");
        Company company8 = new Company("KAMAZ", 1969, "Россия", "Набережные Челны");
        companies.Add(company1);
        companies.Add(company2);
        companies.Add(company3);
        companies.Add(company4);
        companies.Add(company5);
        companies.Add(company6);
        companies.Add(company7);
        companies.Add(company8);
        var res = from ceh in factory
                  from car in ceh
                  where car is Car
                  join t in companies on ((Car)car).Brend equals t.Brend
                  select new
                  {
                      Brend = car.Brend,
                      AddressCompanyCountry = t.Country,
                      AddressCompanyCity = t.City
                  };
        return res;
    }

    public static IEnumerable<dynamic> RequestJoinEx(Queue<List<Car>> factory)
    {
        if (factory.Count == 0)
        {
            return null;
        }
        List<Company> companies = new List<Company>();
        Company company1 = new Company("Ford", 1920, "США", "Детройт");
        Company company2 = new Company("Volvo", 1927, "Швеция", "Гетеборг");
        Company company3 = new Company("Honda", 1948, "Япония", "Хамамацу");
        Company company4 = new Company("Volkswagen", 1938, "Германия", "Вольфсбург");
        Company company5 = new Company("Nissan", 1934, "Япония", "Йокогама");
        Company company6 = new Company("BMW", 1922, "Германия", "Мюнхен");
        Company company7 = new Company("Lada", 1966, "Россия", "Тольятти");
        Company company8 = new Company("KAMAZ", 1969, "Россия", "Набережные Челны");
        companies.Add(company1);
        companies.Add(company2);
        companies.Add(company3);
        companies.Add(company4);
        companies.Add(company5);
        companies.Add(company6);
        companies.Add(company7);
        companies.Add(company8);
        var res = factory.SelectMany(ceh => ceh).Join(companies, company => company.Brend, car => car.Brend,
            (car, company) => new
            {
                Brend = car.Brend,
                AddressCompanyCountry = company.Country,
                AddressCompanyCity = company.City
            });
        return res;
    }

    public static void PrintRequestJoin(IEnumerable<dynamic> res)
    {
        if (res is null || res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет машин для объединения");
        }
        else
        {
            foreach (var item in res)
            {
                Console.WriteLine(line);
                Console.WriteLine(item.ToString());
                Console.WriteLine(line);
            }
        }
    }



    public static IEnumerable<Car> RequestWhereLINQTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            return null;
        }
        else
        {
            var res = from car in collection
                      where car is OffRoadCar && ((OffRoadCar)car).Awd == true
                      select car;
            return res;
        }
    }

    public static IEnumerable<Car> RequestWhereExTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            return null;
        }
        else
        {
            var res = collection.Where(car => car is OffRoadCar && ((OffRoadCar)car).Awd == true);
            return res;
        }
    }

    public static void PrintRequestWhereTwo(IEnumerable<Car> res)
    {
        if (res is null || res.Count() == 0)
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

    public static int RequestCountLINQTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            return 0;
        }
        else
        {
            var res = (from car in collection
                       where car is LorryCar
                       select car).Count();
            return res;
        }
    }

    public static int RequestCountExTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            return 0;
        }
        else
        {
            var res = collection.Where(car => car is LorryCar).Count();
            return res;
        }
    }

    public static void PrintRequestCountTwo(int res)
    {
        if (res  == 0)
        {
            Console.WriteLine("В коллекции нет таких машин");
        }
        else
        {
            Console.WriteLine($"Количество грузовиков: {res}");
        }
    }

    public static int RequestSumLINQTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            return 0;
        }
        else
        {
            var res = (from car in collection
                       where (car is not OffRoadCar) && (car is PassengerCar)
                       select ((PassengerCar)car).CountSeats).Sum();
            return res;
        }
    }

    public static int RequestSumExTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            return 0;
        }
        else
        {
            var res = collection.Where(car => ((car is not OffRoadCar) && (car is PassengerCar))).Select(car => ((PassengerCar)car).CountSeats).Sum();
            return res;
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

    public static IEnumerable<IGrouping<string, Car>> RequestGroupLINQTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            return null;
        }
        else
        {
            var res = from car in collection
                      where car is not null
                      group car by car.Brend;
            return res;
        }
    }

    public static IEnumerable<IGrouping<string, Car>> RequestGroupExTwo(MyCollection<Car> collection)
    {
        if (collection.Count == 0)
        {
            return null;
        }
        else
        {
            var res = collection.Where(car => car is not null).GroupBy(car => car.Brend);
            return res;
        }
    }

    public static void PrintRequestGroupTwo(IEnumerable<IGrouping<string, Car>> res)
    {
        if (res is null || res.Count() == 0)
        {
            Console.WriteLine("В коллекции нет машин дял группировки");
        }
        else
        {
            foreach (var item in res)
            {
                Console.WriteLine($"\n\nБренд группы: {item.Key}");
                Console.WriteLine($"Количество машин в группе: {item.Count()}");
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