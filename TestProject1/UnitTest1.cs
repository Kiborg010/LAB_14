using ClassLibrary1;
using lab14;
using LAB_12_4;
using LAB_12_2;
using System.Collections.Generic;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateFactory()
        {
            Queue<List<Car>> factory = Requests.CreateFactory(); 
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestPrintEmptyFactory()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.PrintFactory(factory);
            Assert.AreEqual(factory.Count, 0);
        }

        [TestMethod]
        public void TestPrintNotEmptyFactory()
        {
            Queue<List<Car>> factory = Requests.CreateFactory();
            Requests.PrintFactory(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestWhere()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            var req1 = Requests.RequestWhereLINQ(factory);
            var req2 = Requests.RequestWhereEx(factory);
            
            Requests.PrintRequestWhere(req1);
            Assert.AreEqual(req1, null);
            Assert.AreEqual(req2, null);

            List<Car> list1 = new List<Car>();
            List<Car> list2 = new List<Car>();
            List<Car> list3 = new List<Car>();
            List<Car> list4 = new List<Car>();
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("1", 2000, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("1", 2000, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("1", 2000, "1", 1, 1, 1, 1, 1, true, "1");
            list1.Add(car1);
            list2.Add(car2);
            list3.Add(car3);
            list4.Add(car4);
            factory.Enqueue(list1);
            factory.Enqueue(list2);
            factory.Enqueue(list3);
            factory.Enqueue(list4);
            
            List<Car> req3 = Requests.RequestWhereLINQ(factory).ToList();
            Assert.AreEqual(req3[0], car4);
            
            List<Car> req4 = Requests.RequestWhereEx(factory).ToList();
            Assert.AreEqual(req4[0], car4);

            Requests.PrintRequestWhere(req3);
        }

        [TestMethod]
        public void TestRequestUnion()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            var req1 = Requests.RequestUnionLINQ(factory);
            var req2 = Requests.RequestUnionEx(factory);

            Requests.PrintRequestUnion(req1);
            Assert.AreEqual(req1, null);
            Assert.AreEqual(req2, null);

            List<Car> list1 = new List<Car>();
            List<Car> list2 = new List<Car>();
            List<Car> list3 = new List<Car>();
            List<Car> list4 = new List<Car>();
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("1", 2000, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("1", 2000, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("1", 2000, "1", 1, 1, 1, 1, 1, true, "1");
            list1.Add(car1);
            list2.Add(car2);
            list3.Add(car3);
            list4.Add(car4);
            factory.Enqueue(list1);
            factory.Enqueue(list2);
            factory.Enqueue(list3);
            factory.Enqueue(list4);

            List<Car> req3 = Requests.RequestUnionLINQ(factory).ToList();
            Assert.AreEqual(req3[1], car2);
            Assert.AreEqual(req3[0], car4);

            List<Car> req4 = Requests.RequestUnionEx(factory).ToList();
            Assert.AreEqual(req4[1], car2);
            Assert.AreEqual(req4[0], car4);

            Requests.PrintRequestUnion(req3);
        }


        [TestMethod]
        public void TestRequestSum()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            var req1 = Requests.RequestSumLINQ(factory);
            var req2 = Requests.RequestSumEx(factory);

            Requests.PrintRequestSum(req1);
            Assert.AreEqual(req1, 0);
            Assert.AreEqual(req2, 0);

            List<Car> list1 = new List<Car>();
            List<Car> list2 = new List<Car>();
            List<Car> list3 = new List<Car>();
            List<Car> list4 = new List<Car>();
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("1", 2000, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("1", 2000, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("1", 2000, "1", 1, 1, 1, 1, 1, true, "1");
            list1.Add(car1);
            list2.Add(car2);
            list3.Add(car3);
            list4.Add(car4);
            factory.Enqueue(list1);
            factory.Enqueue(list2);
            factory.Enqueue(list3);
            factory.Enqueue(list4);

            int req3 = Requests.RequestSumLINQ(factory);
            Assert.AreEqual(req3, 1);

            int req4 = Requests.RequestSumEx(factory);
            Assert.AreEqual(req4, 1);

            Requests.PrintRequestSum(req3);
        }

        [TestMethod]
        public void TestRequestGroup()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            var req1 = Requests.RequestGroupLINQ(factory);
            var req2 = Requests.RequestGroupEx(factory);

            Requests.PrintRequestGroup(req1);
            Assert.AreEqual(req1, null);
            Assert.AreEqual(req2, null);

            List<Car> list1 = new List<Car>();
            List<Car> list2 = new List<Car>();
            List<Car> list3 = new List<Car>();
            List<Car> list4 = new List<Car>();
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("1", 2000, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("1", 2000, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("1", 2000, "1", 1, 1, 1, 1, 1, true, "1");
            list1.Add(car1);
            list2.Add(car2);
            list3.Add(car3);
            list4.Add(car4);
            factory.Enqueue(list1);
            factory.Enqueue(list2);
            factory.Enqueue(list3);
            factory.Enqueue(list4);

            List<IGrouping<string, Car>> req3 = Requests.RequestGroupLINQ(factory).ToList();
            Assert.AreEqual(req3[0].Count(), 4);

            List<IGrouping<string, Car>> req4 = Requests.RequestGroupEx(factory).ToList();
            Assert.AreEqual(req4[0].Count(), 4);

            Requests.PrintRequestGroup(req3);
        }

        [TestMethod]
        public void TestRequestJoin()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            var req1 = Requests.RequestJoinLINQ(factory);
            var req2 = Requests.RequestJoinEx(factory);

            Requests.PrintRequestJoin(req1);
            Assert.AreEqual(req1, null);
            Assert.AreEqual(req2, null);

            List<Car> list1 = new List<Car>();
            List<Car> list2 = new List<Car>();
            List<Car> list3 = new List<Car>();
            List<Car> list4 = new List<Car>();
            Car car1 = new Car("KAMAZ", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("KAMAZ", 2000, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("KAMAZ", 2000, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("KAMAZ", 2000, "1", 1, 1, 1, 1, 1, true, "1");
            list1.Add(car1);
            list2.Add(car2);
            list3.Add(car3);
            list4.Add(car4);
            factory.Enqueue(list1);
            factory.Enqueue(list2);
            factory.Enqueue(list3);
            factory.Enqueue(list4);

            var req3 = Requests.RequestJoinLINQ(factory).ToList();
            Assert.AreEqual(req3.Count(), 4);

            var req4 = Requests.RequestJoinEx(factory).ToList();
            Assert.AreEqual(req4.Count(), 4);

            Requests.PrintRequestJoin(req3);
        }

        [TestMethod]
        public void TestCreateFactoryTwo()
        {
            MyCollection<Car> factory = Requests.CreateCars();
            Assert.AreEqual(factory.Count, 12);
        }

        [TestMethod]
        public void TestRequestWhereTwo()
        {
            MyCollection<Car> factory = new MyCollection<Car>();
            var req1 = Requests.RequestWhereLINQTwo(factory);
            var req2 = Requests.RequestWhereExTwo(factory);

            Requests.PrintRequestWhere(req1);
            Assert.AreEqual(req1, null);
            Assert.AreEqual(req2, null);

            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("2", 2000, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("3", 2000, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("4", 2000, "1", 1, 1, 1, 1, 1, true, "1");
            factory.Add(car1);
            factory.Add(car2);
            factory.Add(car3);
            factory.Add(car4);

            List<Car> req3 = Requests.RequestWhereLINQTwo(factory).ToList();
            Assert.AreEqual(req3[0], car4);

            List<Car> req4 = Requests.RequestWhereExTwo(factory).ToList();
            Assert.AreEqual(req4[0], car4);

            Requests.PrintRequestWhereTwo(req3);
        }

        [TestMethod]
        public void TestRequestCountTwo()
        {
            MyCollection<Car> factory = new MyCollection<Car>();
            var req1 = Requests.RequestCountLINQTwo(factory);
            var req2 = Requests.RequestCountExTwo(factory);

            Requests.PrintRequestCountTwo(req1);
            Assert.AreEqual(req1, 0);
            Assert.AreEqual(req2, 0);

            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("2", 2000, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("3", 2000, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("4", 2000, "1", 1, 1, 1, 1, 1, true, "1");
            factory.Add(car1);
            factory.Add(car2);
            factory.Add(car3);
            factory.Add(car4);

            int req3 = Requests.RequestCountLINQTwo(factory);
            Assert.AreEqual(req3, 1);

            int req4 = Requests.RequestCountExTwo(factory);
            Assert.AreEqual(req4, 1);

            Requests.PrintRequestCountTwo(req3);
        }

        [TestMethod]
        public void TestRequestSumTwo()
        {
            MyCollection<Car> factory = new MyCollection<Car>();
            var req1 = Requests.RequestSumLINQTwo(factory);
            var req2 = Requests.RequestSumExTwo(factory);

            Requests.PrintRequestSumTwo(req1);
            Assert.AreEqual(req1, 0);
            Assert.AreEqual(req2, 0);

            List<Car> list1 = new List<Car>();
            List<Car> list2 = new List<Car>();
            List<Car> list3 = new List<Car>();
            List<Car> list4 = new List<Car>();
            Car car1 = new Car("1", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("2", 2000, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("3", 2000, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("4", 2000, "1", 1, 1, 1, 1, 1, true, "1");
            factory.Add(car1);
            factory.Add(car2);
            factory.Add(car3);
            factory.Add(car4);

            int req3 = Requests.RequestSumLINQTwo(factory);
            Assert.AreEqual(req3, 1);

            int req4 = Requests.RequestSumExTwo(factory);
            Assert.AreEqual(req4, 1);

            Requests.PrintRequestSumTwo(req3);
        }

        [TestMethod]
        public void TestRequestGroupTwo()
        {
            MyCollection<Car> factory = new MyCollection<Car>();
            var req1 = Requests.RequestGroupLINQTwo(factory);
            var req2 = Requests.RequestGroupExTwo(factory);

            Requests.PrintRequestGroupTwo(req1);
            Assert.AreEqual(req1, null);
            Assert.AreEqual(req2, null);

            List<Car> list1 = new List<Car>();
            List<Car> list2 = new List<Car>();
            List<Car> list3 = new List<Car>();
            List<Car> list4 = new List<Car>();
            Car car1 = new Car("KAMAZ", 2000, "1", 1, 1, 1);
            LorryCar car2 = new LorryCar("KAMAZ", 2001, "1", 1, 1, 1, 1);
            PassengerCar car3 = new PassengerCar("KAMAZ", 2002, "1", 1, 1, 1, 1, 1);
            OffRoadCar car4 = new OffRoadCar("KAMAZ", 2003, "1", 1, 1, 1, 1, 1, true, "1");
            factory.Add(car1);
            factory.Add(car2);
            factory.Add(car3);
            factory.Add(car4);

            List<IGrouping<string, Car>> req3 = Requests.RequestGroupLINQTwo(factory).ToList();
            Assert.AreEqual(req3[0].Count(), 4);

            List<IGrouping<string, Car>> req4 = Requests.RequestGroupExTwo(factory).ToList();
            Assert.AreEqual(req4[0].Count(), 4);

            Requests.PrintRequestGroupTwo(req3);
        }
    }
}