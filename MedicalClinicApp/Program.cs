using MedicalClinicApp.Data;
using MedicalClinicApp.Entities;
using MedicalClinicApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new MedicalClinicAppDbContext());

AddEmployee(employeeRepository);
AddNurse(employeeRepository);
AddDoctor(employeeRepository);

WriteAllToConsole(employeeRepository);

static void AddEmployee(IRepository<Employee> empRepository)
{
    empRepository.Add(new Employee { FirstName = "Damian" });
    empRepository.Save();
}

static void AddNurse(IRepository<Employee> nurseRepository)
{
    nurseRepository.Add(new Nurse { FirstName = "Wacława" });
    nurseRepository.Add(new Nurse { FirstName = "Filomena" });
    nurseRepository.Save();
}

static void AddDoctor(IRepository<Employee> doctorRepository)
{
    doctorRepository.Add(new Doctor { FirstName = "Magdalena" });
    doctorRepository.Save();
}

static void WriteAllToConsole(IRepository<Employee> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}