using StorageApp.Repositories;
using StorageApp.Entities;
using StorageApp.Data;

namespace StorageApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // create instance of delegate which points to method EmployeeAdded
            var itemAdded = new ItemAdded(EmployeeAdded);
            // EmployeeAdded method will be called every time when employee is added (AddEmployees method)
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext(),
                itemAdded);
            AddEmployees(employeeRepository);
            AddManger(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadKey();
        }

        private static void EmployeeAdded(object item)
        {
            var employee = (Employee)item;
            Console.WriteLine($"Employee added => {employee.FirstName}");
        }

        private static void AddManger(IWriteRepository<Manager> managerRepository)
        {
            Manager saraManager = new Manager { FirstName = "Sara" };
            var saraManagerCopy = saraManager.Copy<Manager>();

            if(saraManagerCopy != null)
            {
                saraManagerCopy.FirstName += "_copy";
                managerRepository.Add(saraManagerCopy);
            }
            managerRepository.Add(saraManager);
            managerRepository.Add(new Manager { FirstName = "Henry" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IReadRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with id 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Julian" },
                new Employee { FirstName = "Ola" },
                new Employee { FirstName = "Thomas" }
            };
            employeeRepository.AddBatch(employees);
            employeeRepository.Save();
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { FirstName = "Apple" },
                new Organization { FirstName = "Microsoft" }
            };

            organizationRepository.AddBatch(organizations);
        }
    }
}