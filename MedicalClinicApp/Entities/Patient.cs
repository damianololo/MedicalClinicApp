namespace MedicalClinicApp.Entities
{
    public class Patient : EntityBase
    {
        //public string Name { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}
