using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PatientApp.Service;
using System;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;

namespace PatientApp.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        
        private IMyNavigationService navigationService;

        public RelayCommand PatientCmd { get; set; }
        public RelayCommand TestCmd { get; set; }
        public RelayCommand OrderCmd { get; set; }


        public MainViewModel(IMyNavigationService navService)
        {
            
            navigationService = navService;
            InitCommand();
        }

        public void InitCommand()
        {
            PatientCmd = new RelayCommand(() =>
            {
                navigationService.NavigateTo(ViewModelLocator.PatientKey);
            });

            TestCmd = new RelayCommand(() =>
            {
                navigationService.NavigateTo(ViewModelLocator.TestKey);
            });

            OrderCmd = new RelayCommand(() =>
            {
                navigationService.NavigateTo(ViewModelLocator.OrderKey);
            });
        }
    }
}