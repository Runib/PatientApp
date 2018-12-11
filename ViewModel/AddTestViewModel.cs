using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PatientApp.Helper;
using PatientApp.localhost1;
using PatientApp.Model;
using PatientApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PatientApp.ViewModel
{
    public class AddTestViewModel : ViewModelBase, IDataErrorInfo
    {
        private WebService servObj;

        private IMyNavigationService navigationService;
        public RelayCommand BackCmd { get; set; }
        public RelayCommand AddTestCmd { get; set; }
        public RelayCommand OnLoad { get; set; }


        private List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        public List<int> Numbers
        {
            get { return numbers; }
            set { numbers = value; RaisePropertyChanged(() => Numbers); }
        }


        public bool IsValidAdd
        {
            get
            {
                return !string.IsNullOrWhiteSpace(TestType) && !string.IsNullOrWhiteSpace(SelectedTitle) && SelectedPriority!=0
                    && !string.IsNullOrWhiteSpace(TestSpecimenCode);
            }
        }

        private int selectedPriority;
        public int SelectedPriority
        {
            get { return selectedPriority; }
            set { selectedPriority = value; RaisePropertyChanged(() => SelectedPriority); }
        }


        private string testType;
        public string TestType
        {
            get { return testType; }
            set { testType = value; RaisePropertyChanged(() => TestType); }
        }

        private List<string> testTitle;
        public List<string> TestTitle
        {
            get { return testTitle; }
            set { testTitle = value; RaisePropertyChanged(() => TestTitle); }
        }

        private string selectedTitle;
        public string SelectedTitle
        {
            get { return selectedTitle; }
            set { selectedTitle = value; RaisePropertyChanged(() => SelectedTitle); }
        }

        private string testSpecimenCode;
        public string TestSpecimenCode
        {
            get { return testSpecimenCode; }
            set { testSpecimenCode = value; RaisePropertyChanged(() => TestSpecimenCode); }
        }

        private int testOrderNumer;
        public int TestOrderNumber
        {
            get { return testOrderNumer; }
            set { testOrderNumer = value; RaisePropertyChanged(() => TestOrderNumber); }
        }

        private string error = String.Empty;
        public string Error
        {
            get
            {
                return error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                error = string.Empty;
                if (columnName == "TestType" && string.IsNullOrWhiteSpace(TestType))
                {
                    error = "Type name is required!";
                }
                else if (columnName == "SelectedTitle" && string.IsNullOrWhiteSpace(SelectedTitle))
                {
                    error = "Title is required!";
                }
                else if (columnName == "TestSpecimenCode" && string.IsNullOrWhiteSpace(TestSpecimenCode))
                {
                    error = "SpecimenCode is required";
                }
                else if (columnName == "SelectedPriority" && SelectedPriority==0)
                {
                    error = "Priority is required";
                }

                RaisePropertyChanged("IsValidAdd");
                return error;
            }
        }

        public AddTestViewModel(IMyNavigationService navServ)
        {
            servObj = new WebService();
            TestTitle = new List<string>();
            LoadAllTest();
            if (ViewModelLocator.OrderNumberViewModel != 0)
                TestOrderNumber = ViewModelLocator.OrderNumberViewModel;
            else
                TestOrderNumber = servObj.NextIdOrder();
            navigationService = navServ;
            InitCommand();
        }

        private void LoadAllTest()
        {
            List<Title> titles = servObj.LoadAllTitle().ToList();
            foreach (var item in titles)
            {
                TestTitle.Add(item.Title1);
            }
        }

        private void InitCommand()
        {
            BackCmd = new RelayCommand(() =>
            {
                if (TestType!=null || SelectedPriority!=0 || TestSpecimenCode!=null || SelectedTitle!=null)
                {
                    MessageBoxResult msgResult = MessageBox.Show("Are you sure to back?",
                                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (msgResult == MessageBoxResult.Yes)
                    {
                        TestType = SelectedTitle = TestSpecimenCode = null; SelectedPriority = TestOrderNumber = 0;
                        navigationService.NavigateTo(ViewModelLocator.PatientKey);
                    }
                }
                else
                    navigationService.GoBack();
            });

            AddTestCmd = new RelayCommand(() =>
            {
                if (ViewModelLocator.OrderNumberViewModel!=0)
                {
                    TestModel testModel = new TestModel(SelectedTitle, TestType, 0, TestSpecimenCode, SelectedPriority, false, TestOrderNumber);
                    ViewModelLocator.TestModelList.Add(testModel);
                    //servObj.CreateTestData(ConverterDataBase.toDataBase(testModel));
                    TestType = SelectedTitle = TestSpecimenCode = null; SelectedPriority = TestOrderNumber = 0;
                    navigationService.GoBack();
                }
                
            });

            OnLoad = new RelayCommand(() =>
            {
                TestTitle.Clear();
                LoadAllTest();
                if (ViewModelLocator.OrderNumberViewModel != 0)
                    TestOrderNumber = ViewModelLocator.OrderNumberViewModel;
                else
                    TestOrderNumber = servObj.NextIdOrder();
            });
        }
    }
}
