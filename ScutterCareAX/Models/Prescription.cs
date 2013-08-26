using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazikCare.MobEval.Models
{
    public class Prescription
    {
        public string Drug { get; set; }
        public string Dosage { get; set; }
        public string Direction { get; set; }
        public bool IsMorning { get; set; }
        public bool IsAfternoon { get; set; }
        public bool IsEvening { get; set; }
    }
}
