﻿using MedicalClinicApp.Data;
using MedicalClinicApp.Entities;
using MedicalClinicApp.Repositories;
using MedicalClinicApp.Repositories.Extensions;


Console.WriteLine("|-------------------------------MENU-------------------------------|");
Console.WriteLine("Obsługa pracowników: wybierz (1) \nRejestracja pacjentów: wybierz (2)");
Console.WriteLine("Zakończenie działania programu pod klawiszem 'q'.");
var employeeToFileRepository = new SaveToFileRepository<Employee>();
var patientToFileRepository = new SaveToFileRepository<Patient>();
employeeToFileRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
patientToFileRepository.ItemAdded += PatientRepositoryOnItemAdded;
var input = Console.ReadLine();
while (true)
{
    if (input == "1")
    {
        Console.WriteLine("Aby dodać pracownika wybierz:\n(1) Pracownik\n(2) Pielęgniarka\n(3) Doktor");
        Console.WriteLine("Aby usunąć pracownika z listy wybierz (4)\nWyświetlanie aktualnej listy pracowników: wybierz (5)");
        var input2 = Console.ReadLine();
        if (input2 == "q")
        {
            break;
        }
        else if (input2 == "1")
        {
            Console.WriteLine("Wpisz dane osobowe");
            employeeToFileRepository.Add(new Employee { Name = Console.ReadLine() });
        }
        else if (input2 == "2")
        {
            Console.WriteLine("Wpisz dane osobowe");
            employeeToFileRepository.Add(new Nurse { Name = Console.ReadLine() });
        }
        else if (input2 == "3")
        {
            Console.WriteLine("Wpisz dane osobowe");
            employeeToFileRepository.Add(new Doctor { Name = Console.ReadLine() });
        }
        else if (input2 == "4")
        {
            Console.WriteLine("Kogo wyrzucamy?");
            //employeeToFileRepository.Remove(GetById);
        }
        else if (input2 == "5")
        {
            Console.Clear();
            Console.WriteLine("Lista pracowników");
            employeeToFileRepository.Save();
        }
        else
        {
            Console.WriteLine("błędny wybór");
        }
    }
    else if (input == "2")
    {
        Console.WriteLine("Aby zarejestrować pacjenta: wybierz (1)\nAby wyrejestrować pacjenta: wybierz (2).");
        Console.WriteLine("Aby wyświetlić aktualną listę pacjentów: wybierz (3)");
        var input2 = Console.ReadLine();
        if (input2 == "q")
        {
            break;
        }
        else if (input2 == "1")
        {
            Console.WriteLine("Rejestracja pacjenta");
            patientToFileRepository.Add(new Patient { Name = Console.ReadLine() });
        }
        else if (input2 == "2")
        {
            Console.WriteLine("anulowanie wizyty");
            //patientToFileRepository.Remove("Damian");
        }    
    }
    else if (input == "q")
    {
        break;
    }
    else
    {
        throw new ArgumentException("Invalid value");
    }
}
//employeeToFileRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
//employeeToFileRepository.Add(new Employee { Name = Console.ReadLine() });
//employeeToFileRepository.Add(new Nurse { Name = Console.ReadLine() });
//employeeToFileRepository.Add(new Doctor { Name = Console.ReadLine() });

//employeeToFileRepository.Save();
//employeeToFileRepository.GetAll();

//var employeeRepository = new SqlRepository<Employee>(new MedicalClinicAppDbContext());
//var patientRepository = new SqlRepository<Patient>(new MedicalClinicAppDbContext());

//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
//patientRepository.ItemAdded += PatientRepositoryOnItemAdded;

//AddEmployee(employeeRepository);
//AddPatient(patientRepository);

static void AddEmployee(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
        new Employee {Name = "Damian"},
        new Employee {Name = "Krzysztof"},
        new Employee {Name = "Szymon"},
        new Nurse {Name = "Grzegorz"},
        new Nurse {Name = "Bratysława"},
        new Doctor {Name = "Magdalena"}
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