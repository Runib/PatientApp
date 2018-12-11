using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using PatientApp.localhost1;
using PatientApp.Model;
using PatientApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PatientApp.ViewModel
{

    public class ViewModelLocator
    {
        public static List<TestModel> TestModelList = new List<TestModel>();
        public static Patient SearchPatient = null;
        public static Patient SelectedPatient = null;
        public static string PatientMRNViewModel = null;
        public static int OrderNumberViewModel = 0;

        public const string PatientKey = "PatientView";
        public const string AddPatientKey = "AddPatientView";
        public const string AddOrderKey = "AddOrderView";
        public const string ChoiceKey = "ChoiceView";
        public const string ChangePatientKey = "ChangePatientView";
        public const string OrderKey = "OrderView";
        public const string AddTestKey = "AddTestView";
        public const string TestKey = "TestView";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SetupNavigation();
            SimpleIoc.Default.Register<AddTestViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PatientViewModel>();
            SimpleIoc.Default.Register<AddPatientViewModel>();
            SimpleIoc.Default.Register<AddOrderViewModel>();
            SimpleIoc.Default.Register<ChoiceViewModel>();
            SimpleIoc.Default.Register<ChangePatientViewModel>();
            SimpleIoc.Default.Register<OrderViewModel>();
            SimpleIoc.Default.Register<TestViewModel>();
        }

        private static void SetupNavigation()
        {
            var navigationService = new MyNavigationService();
            navigationService.Configure("PatientView", new System.Uri("../View/PatientView.xaml", UriKind.Relative));
            navigationService.Configure("AddPatientView", new System.Uri("../View/AddPatientView.xaml", UriKind.Relative));
            navigationService.Configure("AddOrderView", new System.Uri("../View/AddOrderView.xaml", UriKind.Relative));
            navigationService.Configure("ChoiceView", new System.Uri("../View/ChoiceView.xaml", UriKind.Relative));
            navigationService.Configure("ChangePatientView", new System.Uri("../View/ChangePatientView.xaml", UriKind.Relative));
            navigationService.Configure("OrderView", new System.Uri("../View/OrderView.xaml", UriKind.Relative));
            navigationService.Configure("AddTestView", new System.Uri("../View/AddTestView.xaml", UriKind.Relative));
            navigationService.Configure("TestView", new System.Uri("../View/TestView.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IMyNavigationService>(() => navigationService);
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public PatientViewModel Patient
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PatientViewModel>();
            }
        }

        public AddPatientViewModel AddPatient
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddPatientViewModel>();
            }
        }

        public AddOrderViewModel AddOrder
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddOrderViewModel>();
            }
        }

        public ChoiceViewModel Choice
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChoiceViewModel>();
            }
        }

        public OrderViewModel Order
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderViewModel>();
            }
        }

        public ChangePatientViewModel ChangePatient
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChangePatientViewModel>();
            }
        }

        public AddTestViewModel AddTest
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddTestViewModel>();
            }
        }

        public TestViewModel Test
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TestViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}