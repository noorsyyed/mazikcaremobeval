using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazikCare.MobEval.ViewModels
{
    public class SymptomsViewModel
    {
        public SymptomsViewModel()
        {
            this.SystemicSymptomList = new ObservableCollection<string> { "Recent change in weight"  ,
"Recent weight loss ( lbs)"};

            this.EyeSymptomList = new ObservableCollection<string> { 
                "Worsening vision",  
"Blurry vision"

            };
            this.CardiovascularSymptomList = new ObservableCollection<string> { 
"Chest pain or discomfort",
"Cold hand",
"Cold foot"  
            };


            this.GastroIntestinalSymptomList = new ObservableCollection<string> { "Increased appetite (polyphagia)" };
            this.GenitourinarySymptomList = new ObservableCollection<string> {
 "Urinary frequency increased",  
"Frequent, small amounts of urine",
"Frequent, full-bladder emptying (polyuria)",  
"Urinary frequency more than twice at night (nocturia)",  
"Vaginal itching or burning",  
"Date of last menstruation",  
"Menses abnormal",  
"Missed the most recent menstrual period",  
"Missed the most recent period and preceding period(s)",  
"Patient thinks she may be pregnant"

            };
            this.EndocrineSymptomList = new ObservableCollection<string> { 
                "Excessive thirst / fluid intake (polydipsia)",
"Unable to perform sex (impotence)",  
"Lack of nocturnal erection",  
"Lack of morning erections",
            };
            this.NeurologicalSymptomList = new ObservableCollection<string> { 
 "Dizziness",  
"Fainting (syncope)",  
"Limping",  
"Tingling of the limbs",  
"Burning sensation in both legs or feet",  
"Burning sensation in the hands and feet (distal)",  
"Numbness of the limbs",  
"Numbness of both feet"
            };

            this.PsychologicalSymptomList = new ObservableCollection<string>
            {
                "Poor school performance"
            };
            this.SkinSymptomList = new ObservableCollection<string>{
 "Itching (pruritus)",
"Skin wound slow to heal"  ,
"Skin lesion: on the feet ( cm)",
"Skin lesion: on the toes ( cm)"  

            };
            this.PediatricScreeningList = new ObservableCollection<string>{
"Parental concern appetite has increased substantially"

            };
        }
        public ObservableCollection<string> SystemicSymptomList { get; set; }
        public ObservableCollection<string> EyeSymptomList { get; set; }
        public ObservableCollection<string> CardiovascularSymptomList { get; set; }
        public ObservableCollection<string> GastroIntestinalSymptomList { get; set; }
        public ObservableCollection<string> GenitourinarySymptomList { get; set; }
        public ObservableCollection<string> EndocrineSymptomList { get; set; }
        public ObservableCollection<string> NeurologicalSymptomList { get; set; }
        public ObservableCollection<string> PediatricScreeningList { get; set; }
        public ObservableCollection<string> SkinSymptomList { get; set; }
        public ObservableCollection<string> PsychologicalSymptomList { get; set; }
    }
}
