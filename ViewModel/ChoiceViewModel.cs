using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PatientApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.ViewModel
{
    public class ChoiceViewModel : ViewModelBase
    {
        private IMyNavigationService navigationService;

        public RelayCommand PatientCmd { get; set; }
        public RelayCommand TestCmd { get; set; }
        public RelayCommand OrderCmd { get; set; }


        public ChoiceViewModel(IMyNavigationService navService)
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
