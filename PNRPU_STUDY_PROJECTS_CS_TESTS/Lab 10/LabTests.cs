using Microsoft.VisualStudio.TestTools.UnitTesting;
using Staff;
using Figure;
using System.Text;
using Order;

namespace Lab10.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()] // TestMethod_Condition_ExpectedResult pattern
        public void EmptyConstructor_ClassInstanceCreation_CorrectResult()
        {
            // AAA pattern
            // arrange
            string expectedName    = "";
            string expectedSurname = "";
            int    expectedAge     = 0;

            // act
            Person obj = new();

            // assert
            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedSurname, obj.Surname);
            Assert.AreEqual(expectedAge, obj.Age);
        }

        [TestMethod()]
        public void ParameterizedConstructor_ClassInstanceCreation_CorrectResult()
        {
            string expectedName    = "Vladimir";
            string expectedSurname = "Bezukh";
            int    expectedAge     = 22;

            Person obj = new(
                name:    expectedName,
                surname: expectedSurname,
                age:     expectedAge
            );

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedSurname, obj.Surname);
            Assert.AreEqual(expectedAge, obj.Age);
        }

        [TestMethod()]
        public void Equals_Сomparisons_CorrectResult()
        {
            Person firstPerson  = new("Name", "Surname", 99);
            Person secondPerson = new("Vladimir", "Bezukh", 22);

            Assert.IsTrue(firstPerson.Equals(firstPerson));
            Assert.IsFalse(firstPerson.Equals(secondPerson));
        }

        [TestMethod()]
        public void CompareTo_Сomparisons_CorrectResult()
        {
            int expectedPersonCompareToPersonResult    = 1;
            int expectedPersonCompareToRectangleResult = 1;

            Person firstPerson  = new("Name", "Surname", 99);
            Person secondPerson = new("Vladimir", "Bezukh", 22);
            Figure.Rectangle rectangle = new(10, 10, new Person("Name", "Surname", 99));

            Assert.AreEqual(expectedPersonCompareToPersonResult, firstPerson.CompareTo(secondPerson));
            Assert.AreEqual(expectedPersonCompareToRectangleResult, firstPerson.CompareTo(rectangle));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), $"This object cannot be compared to a {nameof(Person)}")]
        public void CompareTo_Сomparisons_IncorrectResult()
        {
            Person person = new();
            person.CompareTo(42);
        }

        [TestMethod()]
        public void ChangeName_FunctionCall_CorrectResult()
        {
            string expectedName = "Vladimir";

            Person person = new();
            person.ChangeName(expectedName);

            Assert.AreEqual(expectedName, person.Name);
        }

        [TestMethod()]
        public void GetInfo_FunctionCall_CorrectResult()
        {
            Person obj = new("Vladimir", "Bezukh", 22);

            string expected = $"{nameof(Person)}: {obj.Name}, {obj.Surname}, {obj.Age}";

            Assert.AreEqual(expected, obj.GetInfo());
        }

        [TestMethod()]
        public void GetInfoVirtual_FunctionCall_CorrectResult()
        {
            Person obj = new("Vladimir", "Bezukh", 22);

            string expected = $"{nameof(Person)}: {obj.Name}, {obj.Surname}, {obj.Age}";

            Assert.AreEqual(expected, obj.GetInfoVirtual());
        }

        [TestMethod()]
        public void ShallowCopy_FunctionCall_CorrectResult()
        {
            Person obj = new();
            Person newObj = (Person)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Person));
            Assert.AreNotSame(newObj, obj);
        }

        [TestMethod()]
        public void Clone_FunctionCall_CorrectResult()
        {
            Person obj = new();
            Person newObj = (Person)obj.Clone();

            Assert.IsInstanceOfType(obj, typeof(Person));
            Assert.AreNotSame(newObj, obj);
        }

        [TestMethod()]
        public void ToString_FunctionCall_CorrectResult()
        {
            Person obj = new("Vladimir", "Bezukh", 22);

            string expected = $"Name: {obj.Name, -12} Surname: {obj.Surname, -14} Age: {obj.Age}";

            Assert.AreEqual(expected, obj.ToString());
        }
    }

    [TestClass()]
    public class EmployeeTests
    {
        [TestMethod()]
        public void EmptyConstructor_ClassInstanceCreation_CorrectResult()
        {
            string expectedName     = "";
            string expectedSurname  = "";
            int    expectedAge      = 0;
            string expectedPosition = "";

            Employee obj = new();

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedSurname, obj.Surname);
            Assert.AreEqual(expectedAge, obj.Age);
            Assert.AreEqual(expectedPosition, obj.Position);
        }

        [TestMethod()]
        public void ParameterizedConstructor_ClassInstanceCreation_CorrectResult()
        {
            string expectedName     = "Vladimir";
            string expectedSurname  = "Bezukh";
            int    expectedAge      = 22;
            string expectedPosition = "Teamlead";

            Employee obj = new(
                name:     expectedName,
                surname:  expectedSurname,
                age:      expectedAge,
                position: expectedPosition
            );

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedSurname, obj.Surname);
            Assert.AreEqual(expectedAge, obj.Age);
            Assert.AreEqual(expectedPosition, obj.Position);
        }

        [TestMethod()]
        public void CompareTo_Сomparisons_CorrectResult()
        {
            int expectedEmployeeCompareToEmployeeResult  = 1;
            int expectedEmployeeCompareToRectangleResult = 1;

            Employee firstEmployee  = new("Name", "Surname", 99, "Position");
            Employee secondEmployee = new("Vladimir", "Bezukh", 22, "Teamlead");
            Figure.Rectangle rectangle = new(10, 10, new Person("Name", "Surname", 99));

            Assert.AreEqual(expectedEmployeeCompareToEmployeeResult, firstEmployee.CompareTo(secondEmployee));
            Assert.AreEqual(expectedEmployeeCompareToRectangleResult, firstEmployee.CompareTo(rectangle));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), $"This object cannot be compared to a {nameof(Employee)}")]
        public void CompareTo_Сomparisons_IncorrectResult()
        {
            Employee employee = new();
            employee.CompareTo(42);
        }

        [TestMethod()]
        public void ChangeName_FunctionCall_CorrectResult()
        {
            string expectedName = "Vladimir";

            Employee employee = new();
            employee.ChangeName(expectedName);

            Assert.AreEqual(expectedName, employee.Name);
        }

        [TestMethod()]
        public void GetInfo_FunctionCall_CorrectResult()
        {
            Employee obj = new("Vladimir", "Bezukh", 22, "Teamlead");

            string expected = $"{nameof(Employee)}: {obj.Name}, {obj.Surname}, {obj.Age}, {obj.Position}";

            Assert.AreEqual(expected, obj.GetInfo());
        }

        [TestMethod()]
        public void GetInfoVirtual_FunctionCall_CorrectResult()
        {
            Employee obj = new("Vladimir", "Bezukh", 22, "Teamlead");

            string expected = $"{nameof(Employee)}: {obj.Name}, {obj.Surname}, {obj.Age}, {obj.Position}";

            Assert.AreEqual(expected, obj.GetInfoVirtual());
        }

        [TestMethod()]
        public void ShallowCopy_FunctionCall_CorrectResult()
        {
            Employee obj = new();
            Employee newObj = (Employee)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Employee));
            Assert.AreNotSame(newObj, obj);
        }

        [TestMethod()]
        public void Clone_FunctionCall_CorrectResult()
        {
            Employee obj = new();
            Employee newObj = (Employee)obj.Clone();

            Assert.IsInstanceOfType(obj, typeof(Employee));
            Assert.AreNotSame(newObj, obj);
        }

        [TestMethod()]
        public void ToString_FunctionCall_CorrectResult()
        {
            Employee obj = new("Vladimir", "Bezukh", 22, "Teamlead");

            string expected = $"Name: {obj.Name, -12} Surname: {obj.Surname, -14} Age: {obj.Age}\tPosition: {obj.Position}";

            Assert.AreEqual(expected, obj.ToString());
        }
    }

    [TestClass()]
    public class EngineerTests
    {
        [TestMethod()]
        public void EmptyConstructor_ClassInstanceCreation_CorrectResult()
        {
            string expectedName     = "";
            string expectedSurname  = "";
            int    expectedAge      = 0;
            string expectedPosition = "";

            Engineer obj = new();

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedSurname, obj.Surname);
            Assert.AreEqual(expectedAge, obj.Age);
            Assert.AreEqual(expectedPosition, obj.Position);
        }

        [TestMethod()]
        public void ParameterizedConstructor_ClassInstanceCreation_CorrectResult()
        {
            string expectedName     = "Vladimir";
            string expectedSurname  = "Bezukh";
            int    expectedAge      = 22;
            string expectedPosition = "C# programmer";

            Engineer obj = new(
                name:     expectedName,
                surname:  expectedSurname,
                age:      expectedAge,
                position: expectedPosition
            );

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedSurname, obj.Surname);
            Assert.AreEqual(expectedAge, obj.Age);
            Assert.AreEqual(expectedPosition, obj.Position);
        }

        [TestMethod()]
        public void Equals_Сomparisons_CorrectResult()
        {
            Engineer firstEngineer  = new("Name", "Surname", 99, "Position");
            Engineer secondEngineer = new("Vladimir", "Bezukh", 22, "C# programmer");

            Assert.IsTrue(firstEngineer.Equals(firstEngineer));
            Assert.IsFalse(firstEngineer.Equals(secondEngineer));
        }

        [TestMethod()]
        public void CompareTo_Сomparisons_CorrectResult()
        {
            int expectedEngineerCompareToEngineerResult  = 1;
            int expectedEngineerCompareToRectangleResult = 1;

            Engineer firstEngineer  = new("Name", "Surname", 99, "Position");
            Engineer secondEngineer = new("Vladimir", "Bezukh", 22, "C# programmer");
            Figure.Rectangle rectangle = new(10, 10, new Person("Name", "Surname", 99));

            Assert.AreEqual(expectedEngineerCompareToEngineerResult, firstEngineer.CompareTo(secondEngineer));
            Assert.AreEqual(expectedEngineerCompareToRectangleResult, firstEngineer.CompareTo(rectangle));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), $"This object cannot be compared to a {nameof(Engineer)}")]
        public void CompareTo_Сomparisons_IncorrectResult()
        {
            Engineer engineer = new();
            engineer.CompareTo(42);
        }

        [TestMethod()]
        public void ChangeName_FunctionCall_CorrectResult()
        {
            string expectedName = "Vladimir";

            Engineer engineer = new();
            engineer.ChangeName(expectedName);

            Assert.AreEqual(expectedName, engineer.Name);
        }

        [TestMethod()]
        public void GetInfoVirtual_FunctionCall_CorrectResult()
        {
            Engineer obj = new("Vladimir", "Bezukh", 22, "C# programmer");

            string expected = $"{nameof(Engineer)}: {obj.Name}, {obj.Surname}, {obj.Age}, {obj.Position}";

            Assert.AreEqual(expected, obj.GetInfoVirtual());
        }

        [TestMethod()]
        public void ShallowCopy_FunctionCall_CorrectResult()
        {
            Engineer obj = new();
            Engineer newObj = (Engineer)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Engineer));
            Assert.AreNotSame(newObj, obj);
        }

        [TestMethod()]
        public void ToString_FunctionCall_CorrectResult()
        {
            Engineer obj = new("Vladimir", "Bezukh", 22, "C# programmer");

            string expected = $"Name: {obj.Name, -12} Surname: {obj.Surname, -14} Age: {obj.Age}\tPosition: {obj.Position}";

            Assert.AreEqual(expected, obj.ToString());
        }
    }

    [TestClass()]
    public class WorkerTests
    {
        [TestMethod()]
        public void EmptyConstructor_ClassInstanceCreation_CorrectResult()
        {
            string expectedName     = "";
            string expectedSurname  = "";
            int    expectedAge      = 0;
            string expectedPosition = "";

            Worker obj = new();

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedSurname, obj.Surname);
            Assert.AreEqual(expectedAge, obj.Age);
            Assert.AreEqual(expectedPosition, obj.Position);
        }

        [TestMethod()]
        public void ParameterizedConstructor_ClassInstanceCreation_CorrectResult()
        {
            string expectedName     = "Vladimir";
            string expectedSurname  = "Bezukh";
            int    expectedAge      = 22;
            string expectedPosition = "Electrician";

            Worker obj = new(
                name:     expectedName,
                surname:  expectedSurname,
                age:      expectedAge,
                position: expectedPosition
            );

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedSurname, obj.Surname);
            Assert.AreEqual(expectedAge, obj.Age);
            Assert.AreEqual(expectedPosition, obj.Position);
        }

        [TestMethod()]
        public void CompareTo_Сomparisons_CorrectResult()
        {
            int expectedWorkerCompareToWorkerResult = 1;
            int expectedWorkerCompareToRectangleResult = 1;

            Worker firstWorker  = new("Name", "Surname", 99, "Position");
            Worker secondWorker = new("Vladimir", "Bezukh", 22, "Electrician");
            Figure.Rectangle rectangle = new(10, 10, new Person("Name", "Surname", 99));

            Assert.AreEqual(expectedWorkerCompareToWorkerResult, firstWorker.CompareTo(secondWorker));
            Assert.AreEqual(expectedWorkerCompareToRectangleResult, firstWorker.CompareTo(rectangle));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), $"This object cannot be compared to a {nameof(Worker)}")]
        public void CompareTo_Сomparisons_IncorrectResult()
        {
            Worker worker = new();
            worker.CompareTo(42);
        }

        [TestMethod()]
        public void ChangeName_FunctionCall_CorrectResult()
        {
            string expectedName = "Vladimir";

            Worker worker = new();
            worker.ChangeName(expectedName);

            Assert.AreEqual(expectedName, worker.Name);
        }

        [TestMethod()]
        public void GetInfo_FunctionCall_CorrectResult()
        {
            Worker obj = new("Vladimir", "Bezukh", 22, "Electrician");

            string expected = $"{nameof(Worker)}: {obj.Name}, {obj.Surname}, {obj.Age}, {obj.Position}";

            Assert.AreEqual(expected, obj.GetInfo());
        }

        [TestMethod()]
        public void ShallowCopy_FunctionCall_CorrectResult()
        {
            Worker obj = new();
            Worker newObj = (Worker)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Worker));
            Assert.AreNotSame(newObj, obj);
        }

        [TestMethod()]
        public void ToString_FunctionCall_CorrectResult()
        {
            Worker obj = new("Vladimir", "Bezukh", 22, "Electrician");

            string expected = $"Name: {obj.Name, -12} Surname: {obj.Surname, -14} Age: {obj.Age}\tPosition: {obj.Position}";

            Assert.AreEqual(expected, obj.ToString());
        }
    }

    [TestClass()]
    public class QueriesTests
    {
        [TestMethod()]
        public void GetPersonsOlderThan30_FunctionCall_CorrectResult()
        {
            List<Person> expectedPersonsOlderThan30 = new() {
                new Employee("Vasilisa", "Simonova", 52, "Manager"),
                new Worker("Maksim", "Kuznetsov", 35, "Electrician"),
                new Worker("Fedor", "Sedov", 43, "Plumber")
            };

            List<Person> persons = Lab.GetPersonsOlderThan(Lab.GetPersons(), 30);

            CollectionAssert.AreEqual(expectedPersonsOlderThan30, persons);
        }

        [TestMethod()]
        public void GetElectricianWorkers_FunctionCall_CorrectResult()
        {
            List<Worker> expectedElectricianWorkers = new() {
                new Worker("Maksim", "Kuznetsov", 35, "Electrician"),
                new Worker("Svetlana", "Morozova", 30, "Electrician")
            };

            List<Worker> workers = Lab.GetElectricianWorkers(Lab.GetPersons());

            CollectionAssert.AreEqual(expectedElectricianWorkers, workers);
        }

        [TestMethod()]
        public void GetWorkersFullnames_FunctionCall_CorrectResult()
        {
            List<string> expectedWorkersFullnames = new() {
                "Kuznetsov Maksim",
                "Morozova Svetlana",
                "Sedov Fedor"
            };

            List<string> workersFullnames = Lab.GetWorkersFullnames(Lab.GetPersons());

            CollectionAssert.AreEqual(expectedWorkersFullnames, workersFullnames);
        }
    }

    [TestClass()]
    public class SolveTasksTests
    {

        [TestMethod()]
        public void GetFirstTaskResult_FunctionCall_CorrectResult() {
            var expected = new StringBuilder();
            expected.Append("Вызов функции GetInfo():\n");
            expected.Append("Person: Vladimir, Bezukh, 22\n");
            expected.Append("Person: Vasilisa, Simonova, 52\n");
            expected.Append("Person: Georgii, Gorbachev, 28\n");
            expected.Append("Person: Maksim, Kuznetsov, 35\n");
            expected.Append("Person: Svetlana, Morozova, 30\n");
            expected.Append("Person: Fedor, Sedov, 43\n");
            expected.Append('\n');
            expected.Append("Вызов функции GetInfoVirtual():\n");
            expected.Append("Person: Vladimir, Bezukh, 22\n");
            expected.Append("Employee: Vasilisa, Simonova, 52, Manager\n");
            expected.Append("Engineer: Georgii, Gorbachev, 28, C# developer\n");
            expected.Append("Worker: Maksim, Kuznetsov, 35, Electrician\n");
            expected.Append("Worker: Svetlana, Morozova, 30, Electrician\n");
            expected.Append("Worker: Fedor, Sedov, 43, Plumber");

            Assert.AreEqual(expected.ToString(), Lab.GetFirstTaskResult());
        }
    }

    [TestClass()]
    public class OrderByAgeTests
    {
        [TestMethod]
        public void Copmare_Сomparisons_CorrectResult()
        {
            Person firstPerson      = new("Name", "Surname", 20);
            Person secondPerson     = new("Name", "Surname", 25);
            Rectangle firstRectangle  = new(10, 10, new Person("Name", "Surname", 99));
            Rectangle secondRectangle = new(20, 20, new Person("Name", "Surname", 99));
            OrderByAge order = new();

            Assert.AreEqual(-1, order.Compare(firstPerson, secondPerson));
            Assert.AreEqual(1, order.Compare(secondPerson, firstPerson));
            Assert.AreEqual(0, order.Compare(firstPerson, firstPerson));

            Assert.AreEqual(-1, order.Compare(firstRectangle, firstPerson));
            Assert.AreEqual(1, order.Compare(firstPerson, firstRectangle));
            
            Assert.AreEqual(-1, order.Compare(firstRectangle, secondRectangle));
            Assert.AreEqual(1, order.Compare(secondRectangle, firstRectangle));
            Assert.AreEqual(0, order.Compare(firstRectangle, firstRectangle));

            Assert.AreEqual(-1, order.Compare(firstPerson, 42));
        }
    }

    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        public void EmptyConstructor_ClassInstanceCreation_CorrectResult()
        {
            int expectedWidth  = 0;
            int expectedHeight = 0;
            int expectedArea   = 0;

            Rectangle obj = new();

            Assert.AreEqual(expectedWidth, obj.Width);
            Assert.AreEqual(expectedHeight, obj.Height);
            Assert.AreEqual(expectedArea, obj.Area);
        }

        [TestMethod()]
        public void RandomInit_FunctionCall_CorrectResult()
        {
            double expectedClosedIntervalLeftBoundary  = 0.0;
            double expectedClosedIntervalRightBoundary = 100.0;
            double expectedMinimumArea = 0.0;
            double expectedMaximumArea = 10000.0;

            Rectangle obj = new();
            obj.RandomInit();

            Assert.IsTrue(expectedClosedIntervalLeftBoundary <= obj.Width
                          && obj.Width <= expectedClosedIntervalRightBoundary);
            Assert.IsTrue(expectedClosedIntervalLeftBoundary <= obj.Height
                          && obj.Height <= expectedClosedIntervalRightBoundary);
            Assert.IsTrue(expectedMinimumArea <= obj.Area
                          && obj.Area <= expectedMaximumArea);
        }

        [TestMethod()]
        public void GetInfo_FunctionCall_CorrectResult()
        {
            Rectangle obj = new(10, 10, new Person("Name", "Surname", 99));

            string expected = $"{nameof(Rectangle)}: width = {obj.Width}, height = {obj.Height}.";

            Assert.AreEqual(expected, obj.GetInfo());
        }

        [TestMethod()]
        public void CompareTo_Сomparisons_CorrectResult()
        {
            int expectedRectangleCompareToPersonResult    = -1;
            int expectedRectangleCompareToRectangleResult = -1;

            Rectangle firstRectangle  = new(10, 10, new Person("Name", "Surname", 99));
            Rectangle secondRectangle = new(20, 20, new Person("Name", "Surname", 99));
            Person person = new("Name", "Surname", 99);

            Assert.AreEqual(expectedRectangleCompareToPersonResult, firstRectangle.CompareTo(person));
            Assert.AreEqual(expectedRectangleCompareToRectangleResult, firstRectangle.CompareTo(secondRectangle));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), $"This object cannot be compared to a {nameof(Rectangle)}")]
        public void CompareTo_Сomparisons_IncorrectResult()
        {
            Rectangle rectangle = new();
            rectangle.CompareTo(42);
        }

        [TestMethod()]
        public void ToString_FunctionCall_CorrectResult()
        {
            Rectangle obj = new(10, 10, new Person("Name", "Surname", 99));

            string expected = $"Width: {string.Format("{0:0.00000}", obj.Width), -11} Height: {string.Format("{0:0.00000}", obj.Height), -15} Area: {string.Format("{0:0.00000}", obj.Area)}";

            Assert.AreEqual(expected, obj.ToString());
        }
    }
}