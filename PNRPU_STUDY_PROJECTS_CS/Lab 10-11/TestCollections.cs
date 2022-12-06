using Staff;

namespace Lab11
{
    public class TestCollections
    {
        public List<string> fcString;
        public List<Person> fcPerson;
        public Dictionary<Person, Employee> scPersonEmployee;
        public Dictionary<string, Employee> scStringEmployee;

        public TestCollections()
        {
            fcString = new List<string>();
            fcPerson = new List<Person>();
            scPersonEmployee = new Dictionary<Person, Employee>();
            scStringEmployee = new Dictionary<string, Employee>();
        }

        public void RandomInit(in int countObjects)
        {
            Employee employee;

            for (int i = 0; i < countObjects; ++i)
            {
                employee = new();
                employee.RandomInit();
                fcString.Add(employee.ToString());
                fcPerson.Add(employee.BasePerson);
                scPersonEmployee.Add(employee.BasePerson, employee);
                scStringEmployee.Add(employee.ToString(), employee);
            }
        }
    }
}   