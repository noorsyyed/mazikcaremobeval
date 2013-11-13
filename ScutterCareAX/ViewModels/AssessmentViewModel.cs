using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazikCare.MobEval.ViewModels
{
    public class AssessmentViewModel
    {
        public AssessmentViewModel()
        {   
            this.AssessmentList = new ObservableCollection<string>{
"Type 1 Diabetes Mellitus - Uncontrolled",
"Type 1 Diabetes Mellitus with Manifestations",
"Type 1 Diabetes Mellitus with Complications",
"Type 1 Diabetes Mellitus without Complications",
            };
        }
        public ObservableCollection<string> AssessmentList { get; set; }
    }
}
