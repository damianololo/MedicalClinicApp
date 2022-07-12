using MedicalClinicApp.Data;
using MedicalClinicApp.Entities;
using MedicalClinicApp.Repositories;
using MedicalClinicApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MedicalClinicAppDbContext());
var patientRepository = new SqlRepository<Patient>(new MedicalClinicAppDbContext());

employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
patientRepository.ItemAdded += PatientRepositoryOnItemAdded;

AddEmployee(employeeRepository);
AddPatient(patientRepository);

static void AddEmployee(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
        new Employee {Name = "Damian"},
        new Employee {Name = "Krzysztof"},
        new Employee {Name = "Szymon"},
        new Nurse {Name = "Grzegorz"},
        new Nurse {Name = "Magdalena"},
        new Doctor {Name = "Zuzanna"}
    };
    employeeRepository.AddBatch(employees);
    employeeRepository.WriteAllToConsole();
}

static void AddPatient(IRepository<Patient> patientRepository)
{
    var patients = new[]
    {
        new Patient {Name = "Andżela"},
        new Patient {Name = "Bolo"}
    };
    patientRepository.AddBatch(patients);
    patientRepository.WriteAllToConsole();
}

static void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee added => {e.Name} from {sender?.GetType().Name}");
}

static void PatientRepositoryOnItemAdded(object? sender, Patient p)
{
    Console.WriteLine($"Patient added => {p.Name} from {sender?.GetType().Name}");
}