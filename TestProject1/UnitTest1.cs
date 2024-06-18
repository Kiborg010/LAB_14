using ClassLibrary1;
using lab14;
using LAB_12_4;
using LAB_12_2;
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
        public void TestRequestWhereLINQ()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestWhereLINQ(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestWhereLINQ(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestWhereEx()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestWhereEx(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestWhereEx(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestUnionLINQ()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestUnionLINQ(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestUnionLINQ(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestUnionEx()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestUnionEx(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestUnionEx(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestSumLINQ()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestSumLINQ(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestSumLINQ(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestSumEx()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestSumEx(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestSumEx(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestGroupLINQ()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestGroupLINQ(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestGroupLINQ(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestGroupEx()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestGroupEx(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestGroupEx(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestLetLINQ()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestLetLINQ(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestLetLINQ(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestLetEx()
        {
            Queue<List<Car>> factory = new Queue<List<Car>>();
            Requests.RequestLetEx(factory);
            Assert.AreEqual(factory.Count, 0);
            factory = Requests.CreateFactory();
            Requests.RequestLetEx(factory);
            Assert.AreEqual(factory.Count, 4);
        }

        [TestMethod]
        public void TestRequestWhereLINQTwo()
        {
            MyCollection<Car> cars = new MyCollection<Car>();
            Requests.RequestWhereLINQTwo(cars);
            Assert.AreEqual(cars.Count, 0);
            cars = Requests.CreateCars();
            Requests.RequestWhereLINQTwo(cars);
            Assert.AreEqual(cars.Count, 12);
        }

        [TestMethod]
        public void TestRequestWhereExTwo()
        {
            MyCollection<Car> cars = new MyCollection<Car>();
            Requests.RequestWhereExTwo(cars);
            Assert.AreEqual(cars.Count, 0);
            cars = Requests.CreateCars();
            Requests.RequestWhereExTwo(cars);
            Assert.AreEqual(cars.Count, 12);
        }

        [TestMethod]
        public void TestRequestUnionLINQTwo()
        {
            MyCollection<Car> cars = new MyCollection<Car>();
            Requests.RequestUnionLINQTwo(cars);
            Assert.AreEqual(cars.Count, 0);
            cars = Requests.CreateCars();
            Requests.RequestUnionLINQTwo(cars);
            Assert.AreEqual(cars.Count, 12);
        }

        [TestMethod]
        public void TestRequestUnionExTwo()
        {
            MyCollection<Car> cars = new MyCollection<Car>();
            Requests.RequestUnionExTwo(cars);
            Assert.AreEqual(cars.Count, 0);
            cars = Requests.CreateCars();
            Requests.RequestUnionExTwo(cars);
            Assert.AreEqual(cars.Count, 12);
        }

        [TestMethod]
        public void TestRequestSumLINQTwo()
        {
            MyCollection<Car> cars = new MyCollection<Car>();
            Requests.RequestSumLINQTwo(cars);
            Assert.AreEqual(cars.Count, 0);
            cars = Requests.CreateCars();
            Requests.RequestSumLINQTwo(cars);
            Assert.AreEqual(cars.Count, 12);
        }

        [TestMethod]
        public void TestRequestSumExTwo()
        {
            MyCollection<Car> cars = new MyCollection<Car>();
            Requests.RequestSumExTwo(cars);
            Assert.AreEqual(cars.Count, 0);
            cars = Requests.CreateCars();
            Requests.RequestSumExTwo(cars);
            Assert.AreEqual(cars.Count, 12);
        }

        [TestMethod]
        public void TestRequestGroupLINQTwo()
        {
            MyCollection<Car> cars = new MyCollection<Car>();
            Requests.RequestGroupLINQTwo(cars);
            Assert.AreEqual(cars.Count, 0);
            cars = Requests.CreateCars();
            Requests.RequestGroupLINQTwo(cars);
            Assert.AreEqual(cars.Count, 12);
        }

        [TestMethod]
        public void TestRequestGroupExTwo()
        {
            MyCollection<Car> cars = new MyCollection<Car>();
            Requests.RequestGroupExTwo(cars);
            Assert.AreEqual(cars.Count, 0);
            cars = Requests.CreateCars();
            Requests.RequestGroupExTwo(cars);
            Assert.AreEqual(cars.Count, 12);
        }
    }
}