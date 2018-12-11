using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class OrderViewModel : ViewModelBase
    {
        public RelayCommand AddOrderCmd { get; set; }
        public RelayCommand OnLoad { get; set; }
        public RelayCommand BackCmd { get; set; }
        public RelayCommand DelOrderCmd { get; set; }
        public RelayCommand AddTestCmd { get; set; }
        public RelayCommand DelTestCmd { get; set; }

        private List<OrderModel> Orders;

        private IMyNavigationService navigationService;

        private WebService servObj;

        private bool isSelectedOrder = false;
        public bool IsSelectedOrder
        {
            get { return isSelectedOrder; }
            set { isSelectedOrder = value; RaisePropertyChanged(() => IsSelectedOrder); }
        }

        private bool isSelectedPatient = false;
        public bool IsSelectedPatient
        {
            get { return isSelectedPatient; }
            set { isSelectedPatient = value; RaisePropertyChanged(() => IsSelectedPatient); }
        }

        private List<OrderModel> allOrder;
        public List<OrderModel> AllOrder
        {
            get { return allOrder; }
            set { allOrder = value; RaisePropertyChanged(() => AllOrder); }
        }

        private OrderModel selectedOrder;
        public OrderModel SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value;  RaisePropertyChanged(() => SelectedOrder);  if(SelectedOrder!=null) LoadTest(); CheckIsSelected(); if (ViewModelLocator.SearchPatient == null) DisplatPatientFromOrder(); }
        }

        private List<TestModel> alltests;
        public List<TestModel> AllTests
        {
            get { return alltests; }
            set { alltests = value; RaisePropertyChanged(() => AllTests); }
        }

        private String patientFirstName;
        public String PatientFirstName
        {
            get { return patientFirstName; }
            set { patientFirstName = value; RaisePropertyChanged(() => PatientFirstName); }
        }

        private String patientSecondName;
        public String PatientSecondName
        {
            get { return patientSecondName; }
            set { patientSecondName = value; RaisePropertyChanged(() => PatientSecondName); }
        }

        private String patientMRN;
        public String PatientMRN
        {
            get { return patientMRN; }
            set { patientMRN = value; RaisePropertyChanged(() => PatientMRN); }
        }

        private string searchOrder;
        public string SearchOrder
        {
            get { return searchOrder; }
            set { searchOrder = value; RaisePropertyChanged(() => SearchOrder); SearchOrderMethod(); }
        }

        private void SearchOrderMethod()
        {
            if (SearchOrder != "")
                AllOrder = Orders.Where(p => p.OrderNumber.ToString().Contains(SearchOrder)).ToList();
            else
                AllOrder = Orders;
        }


        public OrderViewModel(IMyNavigationService navService)
        {
            AllTests = new List<TestModel>();
            servObj = new WebService();
            if (ViewModelLocator.SearchPatient == null)
                LoadOrders();
            else
                LoadOrders(ViewModelLocator.SearchPatient.MRN);
            LoadSearchPatient();
            navigationService = navService;
            InitCommand();
        }


        private void InitCommand()
        {
            BackCmd = new RelayCommand(() =>
            {
                PatientFirstName = PatientSecondName = PatientMRN = null;
                ViewModelLocator.SearchPatient = null;
                if (!navigationService.GoBackToMenu())
                {
                    navigationService.NavigateTo(ViewModelLocator.ChoiceKey);
                }
                else
                {
                    navigationService.NavigateTo(ViewModelLocator.PatientKey);
                }

            });

            AddOrderCmd = new RelayCommand(() =>
            {
                ViewModelLocator.PatientMRNViewModel = PatientMRN;
                ViewModelLocator.TestModelList.Clear();
                navigationService.NavigateTo(ViewModelLocator.AddOrderKey);
            });

            OnLoad = new RelayCommand(() =>
            {
                SearchOrder = "";
                Orders.Clear();
                if (ViewModelLocator.SearchPatient == null)
                    LoadOrders();
                else
                    LoadOrders(ViewModelLocator.SearchPatient.MRN);
                LoadSearchPatient();
            });

            DelOrderCmd = new RelayCommand(() =>
            {
                servObj.DeleteOrderData(ConverterDataBase.orderModelToDataBase(SelectedOrder));
                SelectedOrder = null;
                if (ViewModelLocator.SearchPatient == null)
                    LoadOrders();
                else
                    LoadOrders(ViewModelLocator.SearchPatient.MRN);
            });

            AddTestCmd = new RelayCommand(() =>
            {
                ViewModelLocator.OrderNumberViewModel = SelectedOrder.OrderNumber;
                navigationService.NavigateTo(ViewModelLocator.AddTestKey);
            });

            DelTestCmd = new RelayCommand(() =>
            {
                if (SelectedOrder.SelectedTest!=null)
                {
                    servObj.DeleteTestData(SelectedOrder.SelectedTest.TestId);
                    MessageBox.Show("Succesfull",
                                        "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    AllOrder = Orders;
                }
                    
            });
        }

        private void LoadOrders()
        {
            List<TestModel> tList = new List<TestModel>();
            if (SelectedOrder!=null)
            {
                tList =ConverterDataBase.toTestModel(servObj.LoadTestData(SelectedOrder.OrderNumber));
                AllOrder = ConverterDataBase.toOrderModel(servObj.LoadAllOrderData(),tList.ToArray());
                Orders = AllOrder;
            }
            else
            {
                AllOrder = ConverterDataBase.toOrderModel(servObj.LoadAllOrderData());
                Orders = AllOrder;
            }
               
        }

        private void LoadOrders(string PatientMrn)
        {
            List<TestModel> tList = new List<TestModel>();
            if (SelectedOrder != null)
            {
                tList = ConverterDataBase.toTestModel(servObj.LoadTestData(SelectedOrder.OrderNumber));
                AllOrder = ConverterDataBase.toOrderModel(servObj.LoadOrderData(PatientMrn), tList.ToArray());
                Orders = AllOrder;
            }
            else
            {
                AllOrder = ConverterDataBase.toOrderModel(servObj.LoadOrderData(PatientMrn));
                Orders = AllOrder;
            }
                
        }

        private void DisplatPatientFromOrder()
        {
            Patient pat = new Patient();
            servObj = new WebService();
            if (SelectedOrder != null)
            {
                pat = servObj.LoadPatientDataByOrder(ConverterDataBase.orderModelToDataBase(SelectedOrder));
                PatientFirstName = pat.FirstName;
                PatientSecondName = pat.SecondName;
                PatientMRN = pat.MRN;
            }
            else
            {
                PatientFirstName = null;
                PatientSecondName = null;
                PatientMRN = null;
            }
        }

        private void CheckIsSelected()
        {
            if (SelectedOrder == null)
                IsSelectedOrder = false;
            else
            {
                IsSelectedPatient = true;
                IsSelectedOrder = true;
            }
                
        }

        private void LoadTest()
        {
            servObj = new WebService();
            AllTests = ConverterDataBase.toTestModel(servObj.LoadTestData(SelectedOrder.OrderNumber));
            SelectedOrder.AllTests = AllTests;
            SelectedOrder.SelectedTest = AllTests.First();
        }

        private void LoadSearchPatient()
        {
            if (ViewModelLocator.SearchPatient != null)
            {
                PatientFirstName = ViewModelLocator.SearchPatient.FirstName;
                PatientSecondName = ViewModelLocator.SearchPatient.SecondName;
                PatientMRN = ViewModelLocator.SearchPatient.MRN;
                IsSelectedPatient = true;
            }
            else
                IsSelectedPatient = false;
        }
    }
}
