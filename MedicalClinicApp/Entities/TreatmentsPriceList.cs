using System.Text;

namespace MedicalClinicApp.Entities
{
    public class TreatmentsPriceList : EntityBase
    {
        public string Treatment { get; set; }

        public int TreatmentCount { get; set; }

        public double TreatmentStandardPrice { get; set; }

        public double TreatmentHalfPrice { get; set; }

        public bool NationalHealthFundTreatment { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new(1024);

            sb.AppendLine($"{Name} ID:{Id}");
            return sb.ToString();
        }
    }
}
