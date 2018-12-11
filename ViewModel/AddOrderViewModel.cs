using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PatientApp.Helper;
using PatientApp.localhost1;
using PatientApp.Model;
using PatientApp.Service;
using PatientApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientApp.ViewModel
{
    public class AddOrderViewModel : ViewModelBase
    {
        private bool isLoad = true;
        
        private WebService servObj;
        private IMyNavigationService navigationService;

        public RelayCommand OnLoad { get; set; }
        public RelayCommand SelectTestCmd { get; set; }
        public RelayCommand BackCmd { get; set; }
        public RelayCommand AddOrderCmd { get; set; }

        private List<TestModel> selectedTests;
        public List<TestModel> SelectedTests
        {
            get { return selectedTests; }
            set { selectedTests = value; RaisePropertyChanged(() => SelectedTests); }
        }

        private ObservableCollection<string> selectedTitles;
        public ObservableCollection<string> SelectedTitles
        {
            get { return selectedTitles; }
            set { selectedTitles = value; RaisePropertyChanged(() => SelectedTitles); }
        }

        private bool canAdd;
        public bool CanAdd
        {
            get { return SelectedTitles!=null; }
        }


        private DateTime startDate=DateTime.Now;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; RaisePropertyChanged(() => StartDate); if (EndDate < StartDate) EndDate = StartDate; }
        }

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; RaisePropertyChanged(() => EndDate); }
        }


        public AddOrderViewModel(IMyNavigationService navService)
        {
            servObj = new WebService();
            navigationService = navService;
            InitCommand();
            SelectedTests = new List<TestModel>();
            SelectedTitles = new ObservableCollection<string>();
            ClearSelectedTests();
        }

        public void ClearSelectedTests()
        {
            if (isLoad)
                servObj.ClearAllTest();
        }

        private void InitCommand()
        {

            SelectTestCmd = new RelayCommand(() =>
            {

                navigationService.NavigateTo(ViewModelLocator.AddTestKey);
               // SelectTestViewModel selectedTestViewModel = new SelectTestViewModel();

               // var selectTestView = new SelectTestView()
               // {
               //     DataContext = selectedTestViewModel
               // };
               // selectTestView.ShowDialog();

               // SelectedTitles = new ObservableCollection<string>();

               // if (selectedTestViewModel.SelectedTests.Count != 0)
               //{
               //     SelectedTests = selectedTestViewModel.SelectedTests;

               //     foreach (var test in SelectedTests)
               //     {
               //         string title = test.Title;
               //         SelectedTitles.Add(title);
               //     }
               //     CanAdd = true;
               // }
               // isLoad = false;
            });

            BackCmd = new RelayCommand(() =>
            {
                isLoad = true;
                navigationService.NavigateTo(ViewModelLocator.OrderKey);
            });

            AddOrderCmd = new RelayCommand(() =>
            {
                if (EndDate < StartDate)
                {
                    MessageBox.Show("Check your End Date",
                                "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Order ord = new Order { EndDate = EndDate, OrderNumber = servObj.NextIdOrder(), patientMRN = "", StartDate = StartDate};
                    servObj.CreateOrderData(ord,ViewModelLocator.PatientMRNViewModel);
                    List<Test> tests = ConverterDataBase.toDataBase(SelectedTests.ToArray());
                    foreach (var item in tests)
                    {
                        servObj.CreateTestData(item);
                    }
                    isLoad = true;
                    navigationService.NavigateTo(ViewModelLocator.OrderKey);
                }
                    
            });

            OnLoad = new RelayCommand(() =>
            {
                StartDate = DateTime.Now;
                EndDate = DateTime.Now;
                SelectedTests = ViewModelLocator.TestModelList;
                LoadAllTitle();
            });
        }

        private void LoadAllTitle()
        {
            SelectedTitles.Clear();
            foreach (var item in SelectedTests)
            {
                SelectedTitles.Add(item.Title);
            }
        }
    }
}
