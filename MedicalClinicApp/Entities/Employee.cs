namespace MedicalClinicApp.Entities
{
    public class Employee : EntityBase
    {
        //public string? FirstName { get; set; }

        //public string? LastName { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {Name}";
    }
}
