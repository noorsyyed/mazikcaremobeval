using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazikCare.MobEval.ViewModels
{
    public class PlanViewModel
    {
        public PlanViewModel()
        {   
            this.BasicManagementProceduresList = new ObservableCollection<string> { "Dermatologicals Wound Dressings",
"Ulcer Care", 
"Institute Prescribed Exercise Program",
"Diet",
"Low Fat Diet",
"Weight Loss Diet",
"Low Cholesterol Diet",
"Diabetic Diet (null calories)",
"High Protein Diet",
"Controlled Carbohydrate Diet",
"Anticipatory Guidance: Properly Fitting Shoes",
"Patient Education - Dietary",
"Patient Education - Diabetes",
"Diabetes Patient Education - Blood Glucose Monitor",
"Diabetes Patient Education - Blood Glucose Monitor Home",
"Patient Education - Home Insulin Administration"
"Patient Education - Diabetic Foot Care"
"Inquiry And Counseling: Medication Admin And Compliance",
"Self-help Group - Weight Watching",
            };

            this.ClinicalSocialWorkList = new ObservableCollection<string>
            {
                "Consult To Cardiology",
"Consult To Endocrinology",
"Consult To Podiatrist",
"Consult To Ophthalmology",
"Consult To A Nutritionist",
"Consult To Podiatrist",
"Consult To Ophthalmology",
            };
            this.MedicationList = new ObservableCollection<string>{
 "Oral Hypoglycemics",
"Insulin preparations",
"Insulin, Human (Humulin)",
"Insulin, Human - Regular (Humulin-R)",
"Insulin, Human - NPH (Humulin-N)",
"Insulin, Human - Lente (Humulin-L)",
"Insulin, Human - Ultralente (Humulin-U)",
"Insulin, Human - Lispro",
"Insulin, Human - Glargine",
"Insulin, Mixed Beef-Pork - Regular (Iletin I)",
"Insulin, Mixed Beef-Pork - NPH (NPH Iletin I)",
"HMG-CoA Reductase Inhibitors",
            };
            this.MedicalSuppliesList = new ObservableCollection<string>{
"Diabetic Supplies",
"Diabetic Supplies Insulin Syringes U-100",
"Diabetic Supplies Insulin Syringes U-100 Low Dose",
"Diabetic Supplies Stylets For Fingerstick",
"Diabetic Supplies Glucose Monitoring Strips",
"Orthopedic Footwear Diabetics Only",
"Infusion Pump Ambulatory Insulin",
            };
        }
        public ObservableCollection<string> MedicalSuppliesList { get; set; }
        public ObservableCollection<string> ClinicalSocialWorkList { get; set; }
        public ObservableCollection<string> MedicationList { get; set; }
        public ObservableCollection<string> BasicManagementProceduresList { get; set; }
    }
}
