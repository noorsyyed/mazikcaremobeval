using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazikCare.MobEval.ViewModels
{
    public class HistoryViewModel
    {
        public HistoryViewModel()
        {
            this.PastMedicalHistoryList = new ObservableCollection<string>
            {
"Recent medical examination by an ophthalmologist"  ,
"Recent medical examination by a podiatrist"  ,
"Recent self-examination - feet",  
"Recurrent bacterial infections",  
"Premature cardiovascular disease",
"Recent insulin (hypoglycemic) reaction",  
"Insulin reactions occurring frequently",  
"Current medication seems to be helping",  
"Feel current medication is causing a problem",  
"Recently stopped medication",  
"Ran out of medication",  
"Home blood sugar check",  
"Home blood sugar check - result below 80",  
"Home blood sugar check result between 140 - 200",  
"Home blood sugar check - result over 200",  
"Reported tests: urine was positive for sugar",  
"Reported tests: urine was positive for acetone",  
"Baby was large or postmature at delivery",  
"Poor growth and development without neurological deficit",  
"Puberty delayed to age  years old", 
            };

            this.SocialHistoryList = new ObservableCollection<string>{
"Smoking cigarettes (  pack(s)/day)",  
"Seeing an eye doctor regularly",  
"Moderate exercising 3 or more times a week"
            };
            this.EndocrineDisorderList = new ObservableCollection<string>{
            
"History of Diabetes Mellitus",  
"Family history of Diabetes Mellitus Type 1",  
"History of Diabetes Mellitus Diabetic Peripheral Neuropathy",  
"History of Rheumatologic Disorders", 
"History of Charcot's Arthropathy Diabetic"
            };
        }

        public ObservableCollection<string> PastMedicalHistoryList { get; set; }
        public ObservableCollection<string> SocialHistoryList { get; set; }
        public ObservableCollection<string> EndocrineDisorderList { get; set; }
    }
}
