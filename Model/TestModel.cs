using PatientApp.localhost1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace PatientApp.Model
{
    public class TestModel : ViewModelBase
    {
        private string titleField;

        private string typeField;

        private int testIdField;

        private string specimenCodeField;

        private int priorityField;

        private bool isSelectedField;

        private int orderNumberField;

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public int TestId
        {
            get
            {
                return this.testIdField;
            }
            set
            {
                this.testIdField = value;
            }
        }

        /// <remarks/>
        public string SpecimenCode
        {
            get
            {
                return this.specimenCodeField;
            }
            set
            {
                this.specimenCodeField = value;
            }
        }

        /// <remarks/>
        public int Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        public bool isSelected
        {
            get
            {
                return this.isSelectedField;
            }
            set
            {
                this.isSelectedField = value;
                RaisePropertyChanged(() => isSelected);
            }
        }

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

        public TestModel(string Title, string Type, int TestId, string SpecimenCode,int Priority, bool isSelected, int OrderNumber)
        {
            this.Title = Title;
            this.Type = Type;
            this.TestId = TestId;
            this.SpecimenCode = SpecimenCode;
            this.Priority = Priority;
            this.isSelected = isSelected;
            this.OrderNumber = OrderNumber;
        }

    }
}
