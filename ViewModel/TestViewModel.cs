using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PatientApp.Helper;
using PatientApp.localhost1;
using PatientApp.Model;
using PatientApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientApp.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        public RelayCommand AddTestCmd { get; set; }
        public RelayCommand BackCmd { get; set; }
        public RelayCommand OnLoad { get; set; }

        private List<TestModel> Tests;
        private WebService servObj;

        private IMyNavigationService navigationService;

        private List<TestModel> allTest;

        private Patient patientTestModel;
        public Patient PatientTestModel
        {
            get { return patientTestModel; }
            set { patientTestModel = value; RaisePropertyChanged(() => PatientTestModel); }
        }

        private OrderModel orderTestModel;
        public OrderModel OrderTestModel
        {
            get { return orderTestModel; }
            set { orderTestModel = value; RaisePropertyChanged(() => OrderTestModel); }
        }


        private TestModel selectedTest;
        public TestModel SelectedTest
        {
            get { return selectedTest; }
            set { selectedTest = value; RaisePropertyChanged(() => SelectedTest); if (SelectedTest != null) LoadPatientData(); }
        }

        private void LoadPatientData()
        {
            LoadOrderData();
            PatientTestModel = servObj.LoadPatientData(OrderTestModel.patientMRN);
        }

        private void LoadOrderData()
        {
            OrderTestModel = ConverterDataBase.toOrderModel(servObj.LoadOrderDataByOrderNumber(SelectedTest.OrderNumber)).First();
        }

        public List<TestModel> AllTest
        {
            get { return allTest; }
            set { allTest = value; RaisePropertyChanged(() => AllTest); }
        }

        private string searchTestId;
        public string SearchTestId
        {
            get { return searchTestId; }
            set { searchTestId = value; RaisePropertyChanged(() => SearchTestId); GetSearchTest(); }
        }

        private void GetSearchTest()
        {
            if (SearchTestId != "")
                AllTest = Tests.Where(test => test.TestId.ToString().Contains(SearchTestId)).ToList();
            else
                AllTest = Tests;
        }


        public TestViewModel(IMyNavigationService navService)
        {
            servObj = new WebService();
            navigationService = navService;
            InitCommand();
            LoadAllTest();
        }

        private void LoadAllTest()
        {
            AllTest = ConverterDataBase.toTestModel(servObj.LoadAllTestData()).ToList();
            Tests = AllTest;
        }

        private void InitCommand()
        {
            BackCmd = new RelayCommand(() =>
            {
                navigationService.NavigateTo(ViewModelLocator.ChoiceKey);
            });

            AddTestCmd = new RelayCommand(() =>
            {
                navigationService.NavigateTo(ViewModelLocator.AddTestKey);
            });

            OnLoad = new RelayCommand(() =>
            {
                LoadAllTest();
            });
        }
    }
}
