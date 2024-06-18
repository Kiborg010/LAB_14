﻿using ClassLibrary1;
using LAB_12_4;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab14
{
    public class Program
    {

        static void TrashAnswer() //Ненужный вопрос, для того, чтобы просто подождать, пока пользователь будет готов вернуться в меню
        {
            Console.WriteLine();
            Console.Write("Введите что-нибудь, чтобы вернуться в меню: ");
            string trashAnswer = Console.ReadLine();
        }

        static int CorrectInputInt(int left, int right, string message) //Стандартная функция для ввода числа в нужном диапазоне
        {
            Console.WriteLine($"Введите {message}: ");
            Console.Write($"Введите целое число от {left} до {right}: ");
            string input = Console.ReadLine();
            int number;
            bool numberIsCorrect = int.TryParse(input, out number);
            while (!numberIsCorrect || !((left <= number) && (number <= right)))
            {
                Console.WriteLine($"Ошибка. Вам необходимо ввести целое число от {left} до {right}");
                Console.Write($"Введите целое число от {left} до {right}: ");
                input = Console.ReadLine();
                numberIsCorrect = int.TryParse(input, out number);
            }
            return number;
        }


        static void WriteCommandsZero() 
        {
            Console.WriteLine("1. Часть 1. Работа с Queue<List<Car>>");
            Console.WriteLine("2. Часть 2. Работа с MyCollection<Car>");
            Console.WriteLine("3. Завершение работы");
        }

        static void WriteCommandsOne() 
        {
            Console.WriteLine("1. Создать коллекцию типа Queue<List<Car>> из 12 элементов");
            Console.WriteLine("2. Создать коллекцию типа Queue<List<Car>> из заданного количества элементов");
            Console.WriteLine("3. Распечатать коллекцию");
            Console.WriteLine("4. Использовать where. Показать все внедорожники с наличием полного привода");
            Console.WriteLine("5. Использовать union. Показать только внедорожники и грузовики");
            Console.WriteLine("6. Использовать sum. Показать суммарное количество сидений у легковых автомобилей, не считая внедорожников");
            Console.WriteLine("7. Использовать group by. Показать группировку по бренду");
            Console.WriteLine("8. Использовать let. Создать новый тип: бренд и новая цена со скидкой");
            Console.WriteLine("9. Завершение работы");
        }

        static void WriteCommandsTwo() 
        {
            Console.WriteLine("1. Создать коллекцию типа MyCollection<Car> из 12 элементов");
            Console.WriteLine("2. Создать коллекцию типа MyCollection<Car> из заданного количества элементов");
            Console.WriteLine("3. Распечатать коллекцию");
            Console.WriteLine("4. Использовать where. Показать все внедорожники с наличием полного привода");
            Console.WriteLine("5. Использовать union. Показать только внедорожники и грузовики");
            Console.WriteLine("6. Использовать sum. Показать суммарное количество сидений у легковых автомобилей, не считая внедорожников");
            Console.WriteLine("7. Использовать group by. Показать группировку по бренду");
            Console.WriteLine("8. Завершение работы");
        }

        static void Main(string[] args)
        {
            int numberAnswerZero = -1;
            while (numberAnswerZero != 3)
            {
                Console.Clear();
                WriteCommandsZero();
                numberAnswerZero = CorrectInputInt(1, 3, "номер выбранной команды");
                switch (numberAnswerZero)
                {
                    case 1:
                        {
                            int numberAnswerOne = -1;
                            Queue<List<Car>> factory = new Queue<List<Car>>();
                            while (numberAnswerOne != 9)
                            {
                                Console.Clear();
                                WriteCommandsOne();
                                numberAnswerOne = CorrectInputInt(1, 9, "номер выбранной команды");
                                switch (numberAnswerOne)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            factory = Requests.CreateFactory();
                                            Requests.PrintFactory(factory);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            int count1 = CorrectInputInt(1, 20, "количество базовых машин");
                                            int count2 = CorrectInputInt(1, 20, "количество легковых машин");
                                            int count3 = CorrectInputInt(1, 20, "количество внедорожников");
                                            int count4 = CorrectInputInt(1, 20, "количество грузовых машин");
                                            factory = Requests.CreateFactory(count1, count2, count3, count4);
                                            Requests.PrintFactory(factory);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Requests.PrintFactory(factory);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestWhereLINQ(factory);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestWhereEx(factory);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestUnionLINQ(factory);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestUnionEx(factory);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestSumLINQ(factory);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestSumEx(factory);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestGroupLINQ(factory);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestGroupEx(factory);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 8:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestLetLINQ(factory);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestLetEx(factory);
                                            TrashAnswer();
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            int numberAnswerTwo = -1;
                            MyCollection<Car> cars = new MyCollection<Car>();
                            while (numberAnswerTwo != 8)
                            {
                                Console.Clear();
                                WriteCommandsTwo();
                                numberAnswerTwo = CorrectInputInt(1, 8, "номер выбранной команды");
                                switch (numberAnswerTwo)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            cars = Requests.CreateCars();
                                            cars.Print();
                                            TrashAnswer();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            int count1 = CorrectInputInt(1, 20, "количество базовых машин");
                                            int count2 = CorrectInputInt(1, 20, "количество легковых машин");
                                            int count3 = CorrectInputInt(1, 20, "количество внедорожников");
                                            int count4 = CorrectInputInt(1, 20, "количество грузовых машин");
                                            cars = Requests.CreateCars(count1, count2, count3, count4);
                                            cars.Print();
                                            TrashAnswer();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            cars.Print();
                                            TrashAnswer();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestWhereLINQTwo(cars);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestWhereExTwo(cars);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestUnionLINQTwo(cars);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestUnionExTwo(cars);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestSumLINQTwo(cars);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestSumExTwo(cars);
                                            TrashAnswer();
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Запрос через LINQ-запросы\n");
                                            Requests.RequestGroupLINQTwo(cars);
                                            Console.WriteLine();
                                            Console.WriteLine("Запрос через методы расширения\n");
                                            Requests.RequestGroupExTwo(cars);
                                            TrashAnswer();
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Завершение работы");
                            break;
                        }

                }
            }
            

        }
    }
}