using GalaSoft.MvvmLight;
using PatientApp.localhost1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Model
{
    public class OrderModel : ViewModelBase
    {
        private int orderNumberField;

        private System.DateTime startDateField;

        private System.DateTime endDateField;

        private string patientMRNField;

        private TestModel selectedTest;
        public TestModel SelectedTest
        {
            get { return this.selectedTest; }
            set { this.selectedTest = value; RaisePropertyChanged(() => SelectedTest); }
        }

        private List<TestModel> allTests;

        /// <remarks/>
        public int OrderNumber
        {
            get
            {
                return this.orderNumberField;
            }
            set
            {
                this.orderNumberField = value;
            }
        }

        /// <remarks/>
        public System.DateTime StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <remarks/>
        public System.DateTime EndDate
        {
            get
            {
                return this.endDateField;
            }
            set
            {
                this.endDateField = value;
            }
        }

        /// <remarks/>
        public string patientMRN
        {
            get
            {
                return this.patientMRNField;
            }
            set
            {
                this.patientMRNField = value;
            }
        }

        public List<TestModel> AllTests
        {
            get { return allTests; }
            set { allTests = value; RaisePropertyChanged(() => AllTests); }
        }

        public OrderModel(int Number, DateTime EDate, DateTime SDate, string MRN, TestModel[] tests)
        {
            OrderNumber = Number;
            StartDate = SDate;
            EndDate = EDate;
            patientMRN = MRN;
            AllTests = tests.ToList();
            
        }

        public OrderModel(int Number, DateTime EDate, DateTime SDate, string MRN)
        {
            OrderNumber = Number;
            StartDate = SDate;
            EndDate = EDate;
            patientMRN = MRN;
        }

    }
}
