using MedicalClinicApp.DataProviders;
using MedicalClinicApp.Entities;
using MedicalClinicApp.Repositories;
using MedicalClinicApp.Repositories.Extensions;

namespace MedicalClinicApp
{
    public class App : IApp
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Patient> _patientRepository;
        //private readonly ITreatmentsProvider _treatmentsPriceList;

        public App(
            IRepository<Employee> employeeRepository,
            IRepository<Patient> patientRepository
            //ITreatmentsProvider treatmentsPriceList
            )
        {
            _employeeRepository = employeeRepository;
            _patientRepository = patientRepository;
            //_treatmentsPriceList = treatmentsPriceList;
        }

        public void Run()
        {
            Console.WriteLine("I'm here in Run() method");

            //var employeeToFileRepository = new SaveToFileRepository<Employee>();
            //var patientToFileRepository = new SaveToFileRepository<Patient>();
            //employeeToFileRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
            //patientToFileRepository.ItemAdded += PatientRepositoryOnItemAdded;

            //employeeToFileRepository.Add(new Employee { Name = "Damian" });
            //_employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
            var employees = new[]
            {
                new Employee {Name = "a"},
                new Nurse {Name = "b"},
                new Doctor{Name = "c"}
            };
            _employeeRepository.AddBatch(employees);
            _employeeRepository.WriteAllToConsole();


            static void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
            {
                Console.WriteLine($"Employee added => {e.Name} from {sender?.GetType().Name}");
            }

            static void PatientRepositoryOnItemAdded(object? sender, Patient p)
            {
                Console.WriteLine($"Patient added => {p.Name} from {sender?.GetType().Name}");
            }
        }
    }
}
